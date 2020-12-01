using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaipoGrandeApp
{
    /// <summary>
    /// Clase para la generacion de reportes de ventas
    /// </summary>
    /// 
    public class VentasReportes
    {
        public int IdDocumento { get; set; }
        public string Cliente { get; set; }
        public string Pais { get; set; }
        public string EstadoDocumento { get; set; }
        public Nullable<DateTime> FechaEmision { get; set; }
        public Nullable<decimal> PrecioProducto { get; set; }
        public Nullable<decimal> PrecioTransporte { get; set; }
        public Nullable<decimal> Impuesto { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public Nullable<decimal> Total { get; set; }

        public VentasReportes()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdDocumento = 0;
            this.Cliente = string.Empty;
            this.Pais = string.Empty;
            this.EstadoDocumento = string.Empty;
            this.FechaEmision = null;
            this.PrecioProducto = null;
            this.PrecioTransporte = null;
            this.Impuesto = null;
            this.Subtotal = null;
            this.Total = null;
        }
    }
}
