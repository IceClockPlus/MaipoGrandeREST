using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Proceso
{
    /// <summary>
    /// Clase que encapsula los procesos del los pedidos 
    /// </summary>
    public class ProcesoPedido
    {
        public Pedido Pedido { get; set; }

        public ProcesoPedido()
        {
            this.InitClass();
        }

        public void InitClass()
        {
            this.Pedido = new Pedido();
        }


        /// <summary>
        /// Metodo para agregar la informacion del pedido y sus detalles
        /// </summary>
        public void RegistrarNuevoPedido()
        {
            try
            {
                //Agregar pedido a la base de datos
                RepositorioPedido.AgregarPedido(Pedido);
                //Agregar detalle del pedido a la base de datos
                RepositorioDetallePedido.AgregarDetallePedido(Pedido);

                EstadoDocumento estadoDocumento = new EstadoDocumento();
                estadoDocumento.IdEstado = 1;
                estadoDocumento.Read();

                DocumentoVenta documentoVenta = new DocumentoVenta();

                //Asignar el pedido al documento de venta
                documentoVenta.Pedido = this.Pedido;

                documentoVenta.EstadoDocumento = estadoDocumento;

                documentoVenta.Insert();

            }catch(Exception ex)
            {

            }

        }

    }
}
