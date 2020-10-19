using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    /// <summary>
    /// Clase que especifica el detalle sobre lo que se va a solicitar
    /// </summary>
    public class ItemPedido
    {
        /// <summary>
        /// Campo que indica la cantidad en kilos del producto que se solicita
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// Campo que especifica el producto que se va a solicitar
        /// </summary>
        public Producto Producto { get; set; }
        /// <summary>
        /// Campo que indica la calidad del producto solicitado
        /// </summary>
        public string Calidad { get; set; }

        public ItemPedido()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.Cantidad = 0;
            this.Calidad = string.Empty;
            this.Producto = new Producto();
        }
    }
}
