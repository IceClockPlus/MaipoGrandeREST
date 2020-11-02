using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class TipoTransporte
    {
        public int IdTipo { get; set; }
        public string Descripcion { get; set; }

        public TipoTransporte()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdTipo = 0;
            this.Descripcion = string.Empty;
        }

        public void ObtenerTipoTransportepPorId(int id)
        {
            using(var db = new DBEntities())
            {
                try
                {
                    TIPOTRANSPORTE t = db.TIPOTRANSPORTE.Where(tipo => tipo.IDTIPO == id).FirstOrDefault();
                    this.IdTipo = (int)t.IDTIPO;
                    this.Descripcion = t.DESCRIPCION;


                }catch(Exception ex)
                {

                } 



            }

        }
    }
}
