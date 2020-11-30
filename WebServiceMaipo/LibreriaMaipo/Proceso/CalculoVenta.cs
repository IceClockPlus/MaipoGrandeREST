using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Proceso
{
    public class CalculoVenta
    {
        /// <summary>
        /// Documento de venta a calcular
        /// </summary>
        public DocumentoVenta DocumentoVenta;


        public CalculoVenta()
        {
            DocumentoVenta = new DocumentoVenta();
        }

        public decimal CalcularCostoProductos()
        {
            try
            {
                decimal totalPrecio = 0;
                List<ItemPedido> detalle = DocumentoVenta.Pedido.DetallePedido;
                totalPrecio = (decimal)detalle.Where(item => item.Estado == "Aceptado").Sum(item => item.Precio);
                return totalPrecio;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public decimal CalcularCostoTransporte()
        {
            try
            {
                decimal totalTransporte = 0;

                if(DocumentoVenta.PrecioTransporte != null)
                {
                    totalTransporte = (decimal)DocumentoVenta.PrecioTransporte;
                }

                return totalTransporte;
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public decimal CalcularSubtotal()
        {
            try
            {
                decimal subtotal = 0;

                subtotal = (decimal)(this.DocumentoVenta.PrecioProducto + this.DocumentoVenta.PrecioTransporte);

                return subtotal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public decimal CalcularImpuesto()
        {
            try
            {
                decimal impuesto = 0;

                impuesto = (decimal)(this.DocumentoVenta.Subtotal * ImpuestoConstants.Iva);
                return impuesto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public decimal CalcularTotal()
        {
            try
            {
                decimal total = 0;
                total = (decimal)(this.DocumentoVenta.Subtotal + this.DocumentoVenta.Impuesto);
                return total;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public bool CalcularPreciosDocumento()
        {
            try
            {
                this.DocumentoVenta.PrecioProducto = this.CalcularCostoProductos();
                this.DocumentoVenta.PrecioTransporte = this.CalcularCostoTransporte();
                this.DocumentoVenta.Subtotal = this.CalcularSubtotal();
                this.DocumentoVenta.Impuesto = this.CalcularImpuesto();

                this.DocumentoVenta.Total = (int?)this.CalcularTotal();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }

    }
}
