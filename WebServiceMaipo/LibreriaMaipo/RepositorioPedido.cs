using DatoMaipo;
using LibreriaMaipo.Modelo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class RepositorioPedido
    {
        public static Pedido ObtenerPedidoPorId(int idPedido)
        {
            TipoUsuarioFactory factory = new ClienteFactory();
            using (var db = new DBEntities())
            {
                try
                {
                    var queryPedido = db.PEDIDO.Include("CLIENTE").Where(pedido => pedido.IDPEDIDO == idPedido).FirstOrDefault();
                    if(queryPedido == null)
                    {
                        return null;
                    }
                    Pedido p = new Pedido();
                    p.IdPedido = (int)queryPedido.IDPEDIDO;
                    p.FechaPedido = queryPedido.FECHAPEDIDO;
                    p.FechaEntrega = queryPedido.FECHAENTREGA;
                    p.Direccion = queryPedido.DIRECCIONPEDIDO;
                    p.Ciudad = queryPedido.CIUDAD;
                    p.Pais = queryPedido.PAIS;

                    TipoUsuario cli = factory.createTipoUsuario();
                    cli.ObtenerDatosPorId((int)queryPedido.IDCLIENTE);
                    p.Cliente = (Cliente)cli;
                    p.EstadoPedido = RepositorioEstadoPedido.ObtenerEstadoPedidoById((int)queryPedido.IDESTADOPEDIDO);

                    p.DetallePedido = RepositorioDetallePedido.ObtenerDetallePedido((int)p.IdPedido);
                    return p;
               
                }catch(Exception ex)
                {
                    return null;
                }



            }

        }

        public static void AgregarPedido(Pedido pedido)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    var pedidoAgregar = new PEDIDO
                    {
                        //Asignacion de datos del pedido
                        FECHAPEDIDO = pedido.FechaPedido,
                        FECHAENTREGA = pedido.FechaEntrega,
                        DIRECCIONPEDIDO = pedido.Direccion,
                        CIUDAD = pedido.Ciudad,
                        PAIS = pedido.Pais,
                        IDESTADOPEDIDO = 1,
                        IDCLIENTE = pedido.Cliente.Id
                    };
                    //Agregar Pedido a la base de datos
                    db.PEDIDO.Add(pedidoAgregar);
                    //Confirmar el adicion del pedido en la base de datos
                    //Se recupera la id del pedido generada por medio del DbContext
                    int idPedido = (int)pedidoAgregar.IDPEDIDO;


                    foreach (ItemPedido item in pedido.DetallePedido)
                    {
                        DETALLEPEDIDO detalle = new DETALLEPEDIDO()
                        {
                            CANTIDAD = item.Cantidad,
                            CALIDAD = item.Calidad,
                            IDPEDIDO = pedido.IdPedido,
                            IDPRODUCTO = item.Producto.IdProducto
                        };
                        db.DETALLEPEDIDO.Add(detalle);

                    }

                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.StackTrace);
                }

            }

        }
    }
}
