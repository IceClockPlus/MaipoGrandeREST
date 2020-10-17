using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    public class PedidoViewModel
    {
        public String Token { get; set; }
        public String DireccionPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public Nullable<DateTime> FechaEntrega { get; set; }
        public String Ciudad { get; set; }
        public List<ItemPedido> DetallePedido { get; set; }


    }
}