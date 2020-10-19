using LibreriaMaipo.TiposUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    [DataContract]
    public class Pedido
    {
        [DataMember]
        public int IdPedido { get; set; }
        [DataMember]
        public DateTime FechaPedido { get; set; }
        [DataMember]
        public Nullable<DateTime> FechaEntrega { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public EstadoPedido EstadoPedido { get; set; }
        [DataMember]
        public List<ItemPedido> DetallePedido { get; set; }
        

        public Pedido()
        {
            this.InitClass();
        }

        public void InitClass()
        {
            this.IdPedido = 0;
            this.FechaPedido = DateTime.Today;
            this.FechaEntrega = null;
            this.Direccion = string.Empty;
            this.Ciudad = string.Empty;
            this.Pais = string.Empty;
            this.Cliente = new Cliente();
            this.EstadoPedido = new EstadoPedido();
            this.DetallePedido = new List<ItemPedido>();
        }

    }
}
