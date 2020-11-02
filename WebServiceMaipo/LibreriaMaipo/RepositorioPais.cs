using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class RepositorioPais
    {
        public static Pais BuscarPorId(int id)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    PAIS queryPais = db.PAIS.Where(p => p.ID_PAIS == id).FirstOrDefault();
                    Pais pais = new Pais();
                    pais.IdPais = (int)queryPais.ID_PAIS;
                    pais.NombrePais = queryPais.NOMBRE_PAIS;
                    return pais;

                }
                catch (Exception ex)
                {
                    ex.InnerException.ToString();
                    return new Pais();
                }

            }




        }
        public static List<Pais> ListarPaises()
        {
            using(var db = new DBEntities())
            {
                List<Pais> listadoPaises = new List<Pais>();

                try
                {
                    var query = db.PAIS.ToList();
                    foreach(var dbPais in query)
                    {
                        Pais pais = new Pais();
                        pais.IdPais = (int)dbPais.ID_PAIS;
                        pais.NombrePais = dbPais.NOMBRE_PAIS;
                        listadoPaises.Add(pais);
                    }
                    return listadoPaises;

                }catch(Exception ex)
                {
                    ex.InnerException.ToString();
                    return null;
                }


            }

        }




    }
}
