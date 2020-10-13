using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatoMaipo;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity.Infrastructure;

namespace LibreriaMaipo
{
    public class MantenedorProducto
    {
        public static bool Agregar(Producto prod)
        {
            try
            {
                using(var db = new DBEntities())
                {
                    db.SP_INSERT_PRODUCTO(prod.NombreProducto, (decimal)prod.PrecioEstimado, prod.ImagenProducto, prod.BannerProducto);
                    db.SaveChanges();
                    return true;

                }
            }catch(Exception ex)
            {
                return false;
            }

        }

        public static List<Producto> ListarTodos()
        {
            List<Producto> listadoProducto = new List<Producto>();
            try
            {
                using(var db = new DBEntities())
                {
                    var list = db.PRODUCTO.AsNoTracking().ToList();

                    foreach(var prod in list)
                    {
                        listadoProducto.Add(new Producto(prod));

                    }
                }

            }catch(Exception ex)
            {


            }
            return listadoProducto;
        }

        public static Producto BuscarPorId(int id)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var busqueda = db.PRODUCTO.FirstOrDefault(p => p.IDPRODUCTO == id);
                    if (busqueda == null)
                    {
                        return null;
                    }
                    Producto producto = new Producto(busqueda);

                    return producto;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }
}
