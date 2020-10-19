using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    public class PedidoViewModel
    {
        public string Token { get; set; }
        public string DireccionPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public Nullable<DateTime> FechaEntrega { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public List<ItemPedido> DetallePedido { get; set; }


    }
}