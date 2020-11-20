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

                Subasta subasta = new Subasta();
                subasta.Pedido = DocumentoVenta.Pedido;
                if (subasta.ReadByIdPedido())
                {
                    foreach(OfertaSubasta oferta in subasta.OfertasSubasta)
                    {
                        if (oferta.Seleccionado.Equals("1"))
                        {
                            totalTransporte = (decimal)oferta.PrecioOferta;
                            break;
                        }
                    }
                    return totalTransporte;
                }
                else
                {
                    return 0;
                }

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

                this.DocumentoVenta.Total = this.CalcularTotal();
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
