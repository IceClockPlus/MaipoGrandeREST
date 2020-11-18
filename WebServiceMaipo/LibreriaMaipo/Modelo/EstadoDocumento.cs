using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class EstadoDocumento
    {
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }

        public EstadoDocumento()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdEstado = 0;
            this.Descripcion = string.Empty;
        }

        public bool Read()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var estado = db.ESTADODOCUMENTO.Where(est => est.ID == this.IdEstado).FirstOrDefault();
                    if(estado != null)
                    {
                        this.Descripcion = estado.DESCRIPCION;
                        return true;

                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


    }
}
