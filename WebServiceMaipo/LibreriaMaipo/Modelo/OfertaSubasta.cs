using LibreriaMaipo.TiposUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class OfertaSubasta
    {
        public int IdOferta { get; set; }
        public float PrecioOferta { get; set; }
        public string Seleccionado { get; set; }
        public DateTime FechaOferta { get; set; }
        public Transportista Transportista { get; set; }
        public TipoTransporte TipoTransporte { get; set; }

        public OfertaSubasta()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdOferta = 0;
            this.PrecioOferta = 0;
            this.Seleccionado = "0";
            this.FechaOferta = DateTime.Today;
            this.Transportista = new Transportista();
            this.TipoTransporte = new TipoTransporte();
        }
    }
}
