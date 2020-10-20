using DatoMaipo;
using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class RepositorioDetallePedido
    {
        /// <summary>
        /// Metodo para agregar el detalle del pedido dentro en la base de datos
        /// </summary>
        /// <param name="pedido"></param>
        public static void AgregarDetallePedido(Pedido pedido)
        {
            //Crear contexto de EF
            using (var db = new DBEntities())
            {
                try
                {
                    //Obtener los items que compone el detalle del pedido
                    foreach(ItemPedido item in pedido.DetallePedido)
                    {
                        //Crear objeto detalle y asignar valores para su adicion a la base de datos
                        DETALLEPEDIDO detalle = new DETALLEPEDIDO();
                        detalle.IDPEDIDO = pedido.IdPedido;
                        detalle.IDPRODUCTO = item.Producto.IdProducto;
                        detalle.CANTIDAD = item.Cantidad;
                        detalle.CALIDAD = item.Calidad;
                        //Agregar entidad a la base de datos
                        db.DETALLEPEDIDO.Add(detalle);
                    }
                    //Confirmar cambios
                    db.SaveChanges();


                }catch(Exception ex)
                {
                    ex.Message.ToString();
                }

            }

        }
        
        /// <summary>
        /// Obtener los detalles de un pedido por la ID de este ultimo
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        public static List<ItemPedido> ObtenerDetallePedido(int idPedido)
        {
            using (var db = new DBEntities())
            {
                //Crear listado del detalle a devolver
                List<ItemPedido> detallePedido = new List<ItemPedido>();
                try
                {
                    //Realizar consulta del detalle de acuerdo a la id del pedido
                    var queryDetalle = db.DETALLEPEDIDO.Include("PRODUCTO").Where(detalle => detalle.IDPEDIDO == idPedido).ToList();
                    
                    //Crear instancias ItemPedido con los datos obtenidos de la consulta
                    foreach(var detalle in queryDetalle)
                    {
                        ItemPedido item = new ItemPedido();
                        item.Cantidad = (int)detalle.CANTIDAD;
                        item.Calidad = detalle.CALIDAD;
                        item.Producto = new Producto
                        {
                            IdProducto = (int)detalle.IDPRODUCTO,
                            NombreProducto = detalle.PRODUCTO.NOMBREPRODUCTO,
                            PrecioEstimado = (float)detalle.PRODUCTO.PRECIOESTIMADO,
                            ImagenProducto = detalle.PRODUCTO.IMAGENPRODUCTO,
                            BannerProducto = detalle.PRODUCTO.BANNERPRODUCTO
                        };
                        //Agregar objeto a la lista
                        detallePedido.Add(item);

                    }
                    //Devolver listado
                    return detallePedido;


                }catch(Exception ex)
                {

                    ex.Message.ToString();
                    return null;
                }


            }

        }


    }
}
