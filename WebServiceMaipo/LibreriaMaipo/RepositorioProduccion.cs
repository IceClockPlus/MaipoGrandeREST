using DatoMaipo;
using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class RepositorioProduccion
    {
        public static bool AgregarProduccion(Produccion produccion)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    //Asignacion de valores
                    PRODUCCION produc = new PRODUCCION();
                    produc.IDPRODUCTOR = produccion.IdProductor;
                    produc.IDPRODUCTO = produccion.Producto.IdProducto;
                    produc.PRECIOESTANDAR = (decimal)produccion.PrecioEstandar;
                    produc.PRECIOLOWER = (decimal)produccion.PrecioLower;
                    produc.PRECIOPREMIUM = (decimal)produccion.PrecioPremium;
                    db.PRODUCCION.Add(produc);
                    if(db.SaveChanges() ==0 )
                    {
                        return false;
                    }
                    return true;

                }catch(Exception ex)
                {
                    ex.InnerException.ToString();
                    return false;
                }
            }
        }



        /// <summary>
        /// Obtener los productos generados por el productor
        /// </summary>
        /// <param name="idProductor"></param>
        /// <returns></returns>
        public static List<Produccion> ObtenerPorIdProductor(int idProductor)
        {
            using (var db = new DBEntities())
            {
                List<Produccion> listProduccion = new List<Produccion>();
                try
                {
                    var query = db.PRODUCCION.Where(p => p.IDPRODUCTOR == idProductor).ToList();
                    foreach(var dbProd in query)
                    {
                        Produccion produccion = new Produccion();
                        produccion.IdProduccion = (int)dbProd.IDPRODUCCION;
                        produccion.PrecioPremium = (float)dbProd.PRECIOPREMIUM;
                        produccion.PrecioEstandar = (float)dbProd.PRECIOESTANDAR;
                        produccion.PrecioLower = (float)dbProd.PRECIOLOWER;
                        produccion.Producto = MantenedorProducto.BuscarPorId((int)dbProd.IDPRODUCTO);
                        listProduccion.Add(produccion);
                    }
                    return listProduccion;

                }catch(Exception ex)
                {
                    ex.InnerException.ToString();
                    return null;
                }

            }



        }



    }
}
