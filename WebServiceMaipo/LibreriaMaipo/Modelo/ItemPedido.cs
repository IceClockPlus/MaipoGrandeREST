using LibreriaMaipo.TiposUsuario;
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
        /// Campo de identidad del item que se ha solicitado
        /// </summary>
        public int IdItemPedido { get; set; }
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
        /// <summary>
        /// Campo que indica el productor asignado para el item solicitado
        /// </summary>
        public Productor Productor { get; set; }

        public ItemPedido()
        {
            this.InitClass();
        }
        /// <summary>
        /// Inicializacion de la clase 
        /// </summary>
        private void InitClass()
        {
            this.IdItemPedido = 0;
            this.Cantidad = 0;
            this.Calidad = string.Empty;
            this.Producto = new Producto();
            this.Productor = new Productor();
        }


        public void Agregar(int idPedido)
        {



        }


    }
}
