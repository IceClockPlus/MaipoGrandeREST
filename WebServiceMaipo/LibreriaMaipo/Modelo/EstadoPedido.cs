using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    /// <summary>
    /// Clase que indica el estado en el que se encuentra el pedido de los clientes
    /// </summary>
    public class EstadoPedido
    {
        /// <summary>
        /// Campo que indica la identificacion del estado del pedido
        /// </summary>
        public int IdEstado { get; set; }
        /// <summary>
        /// Campo que muestra la descripcion del estado del pedido
        /// </summary>
        public string DescripcionEstado { get; set; }

        public EstadoPedido()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdEstado = 0;
            this.DescripcionEstado = string.Empty;
        }
    }
}
