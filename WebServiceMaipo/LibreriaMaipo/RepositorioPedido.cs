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
        /// <summary>
        /// Obtener datos del Pedido segun su id de pedido
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        public static Pedido ObtenerPedidoPorId(int idPedido)
        {
            //Creacion de una factory de Cliente
            TipoUsuarioFactory factory = new ClienteFactory();
            using (var db = new DBEntities())
            {
                try
                {
                    //Realizar consulta para obtener datos del pedido
                    var queryPedido = db.PEDIDO.Include("CLIENTE").Where(pedido => pedido.IDPEDIDO == idPedido).FirstOrDefault();
                    
                    //Devolver null si la consulta no entrega resultados
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
                    
                    //Crear una instancia cliente con el uso de ClienteFactory
                    TipoUsuario cli = factory.createTipoUsuario();
                    //Recuperar datos del cliente por su id
                    cli.ObtenerDatosPorId((int)queryPedido.IDCLIENTE);

                    p.Cliente = (Cliente)cli;
                    //Obtener el estado del pedido por su id
                    p.EstadoPedido = RepositorioEstadoPedido.ObtenerEstadoPedidoById((int)queryPedido.IDESTADOPEDIDO);
                    //Obtener el detalle del pedido por id
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
                    db.SaveChanges();
                    //Se recupera la id del pedido generada por medio del DbContext
                    pedido.IdPedido = (int)pedidoAgregar.IDPEDIDO;

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.StackTrace);
                }

            }

        }
    }
}
