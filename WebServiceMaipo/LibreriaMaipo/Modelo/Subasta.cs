using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class Subasta
    {
        public int IdSubasta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public EstadoSubasta EstadoSubasta { get; set; }
        public Pedido Pedido { get; set; }
        public List<OfertaSubasta> OfertaSubasta { get; set; }

        public Subasta()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdSubasta = 0;
            this.FechaInicio = DateTime.Today;
            this.FechaTermino = DateTime.Today;
            this.EstadoSubasta = new EstadoSubasta();
            this.Pedido = new Pedido();
            this.OfertaSubasta = new List<OfertaSubasta>();
        }
    }
}
