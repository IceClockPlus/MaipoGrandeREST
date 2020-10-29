using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    [DataContract]
    public class PedidoViewModel:SecurityViewModel
    {
        [DataMember]
        public string DireccionPedido { get; set; }
        [DataMember]
        public DateTime FechaPedido { get; set; }
        [DataMember]
        public Nullable<DateTime> FechaEntrega { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public List<ItemPedido> DetallePedido { get; set; }


    }
}