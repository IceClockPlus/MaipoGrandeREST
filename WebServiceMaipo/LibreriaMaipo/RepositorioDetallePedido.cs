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
        public static void AgregarDetallePedido(List<ItemPedido> detalles)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    foreach(ItemPedido item in detalles)
                    {
                        DETALLEPEDIDO detalle = new DETALLEPEDIDO();



                    }



                }catch(Exception ex)
                {

                }

            }

        }
        
        
        public static List<ItemPedido> ObtenerDetallePedido(int idPedido)
        {
            using (var db = new DBEntities())
            {
                List<ItemPedido> detallePedido = new List<ItemPedido>();
                try
                {

                    var queryDetalle = db.DETALLEPEDIDO.Include("PRODUCTO").Where(detalle => detalle.IDPEDIDO == idPedido).ToList();
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
                        detallePedido.Add(item);

                    }
                    return detallePedido;


                }catch(Exception ex)
                {

                    throw new Exception(ex.Message);
                }


            }

        }


    }
}
