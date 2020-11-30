using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class Pais
    {
        private int _idPais;

        private String _nombrePais;

        public int IdPais
        {
            get 
            { 
                return _idPais; 
            }
            set
            {
                _idPais = value;
            }

        }

        public String NombrePais
        {
            get
            {
                return _nombrePais;
            }
            set
            {
                _nombrePais = value;
            }
        }

        public Pais()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdPais = 0;
            this.NombrePais = String.Empty;
        }


        public bool Read()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var pais = db.PAIS.Where(p => p.ID_PAIS == this.IdPais).FirstOrDefault();

                    this.NombrePais = pais.NOMBRE_PAIS;
                    return true;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                
            }

        }

        /// <summary>
        /// Listar todos los paises registrados
        /// </summary>
        /// <returns></returns>
        public List<Pais> ReadAll()
        {
            try
            {
                List<Pais> list = new List<Pais>();
                using (var db = new DBEntities())
                {
                    var listadoPaises = db.PAIS.ToList();
                    if (listadoPaises.Count()>0)
                    {
                        foreach(var p in listadoPaises)
                        {
                            Pais pais = new Pais();
                            pais.IdPais = (int)p.ID_PAIS;
                            pais.NombrePais = p.NOMBRE_PAIS;
                            list.Add(pais);

                        }
                    }
                    return list;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Pais>();
            }

        }



    }
}
