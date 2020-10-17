using LibreriaMaipo.TiposUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public Nullable<DateTime> FechaEntrega { get; set; }
        public String Direccion { get; set; }
        public String Ciudad { get; set; }
        public Cliente Cliente { get; set; }
        public EstadoPedido EstadoPedido { get; set; }
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
            this.Direccion = String.Empty;
            this.Ciudad = String.Empty;
            this.Cliente = new Cliente();
            this.EstadoPedido = new EstadoPedido();
            this.DetallePedido = new List<ItemPedido>();
        }

    }
}
