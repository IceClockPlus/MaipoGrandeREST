using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DatoMaipo;

namespace LibreriaMaipo
{
    public class RepositorioPaises
    {
        public static List<Pais> listarPaises()
        {
            List<Pais> listado = new List<Pais>();
            using(var db = new DBEntities())
            {
                var ls = db.PAIS.ToList();

                foreach(var x in ls)
                {
                    Pais p = new Pais();
                    p.IdPais = (int)x.ID_PAIS;
                    p.NombrePais = x.NOMBRE_PAIS;
                    listado.Add(p);
                }
            }
            return listado;
        }

        public static Pais buscaPaisNombre(string nomPais)
        {
            Pais pais = new Pais();
            using(var db = new DBEntities())
            {
                /*Buscar pais por su nombre*/
                var p = db.PAIS.Where(x => x.NOMBRE_PAIS == nomPais).FirstOrDefault();
                
                /*Si no encuentra un pais con el nombre, regresa nulo*/
                if (p == null)
                {
                    return null;
                }

                /*Conversion a clase de libreria*/
                pais.IdPais = (int)p.ID_PAIS;
                pais.NombrePais = p.NOMBRE_PAIS;

            }
            return pais;

        }
    }
}
