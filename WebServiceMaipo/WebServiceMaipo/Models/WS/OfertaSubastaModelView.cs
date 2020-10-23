using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    public class OfertaSubastaModelView
    {
        public int IdUsuario { get; set; }
        public int IdSubasta { get; set; }
        public float PrecioOferta { get; set; }
        public int IdTipoTransporte { get; set; }
    }
}