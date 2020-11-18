using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class DocumentoVenta
    {
        public int IdDocumento { get; set; }
        public Nullable<DateTime> FechaEmision { get; set; }
        public Nullable<decimal> PrecioProducto { get; set; }
        public Nullable<decimal> PrecioTransporte { get; set; }
        public Nullable<decimal> Impuesto { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Pedido Pedido { get; set; }
        public EstadoDocumento EstadoDocumento { get; set; }

        public DocumentoVenta()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdDocumento = 0;
            this.FechaEmision = null;
            this.PrecioProducto = null;
            this.PrecioTransporte = null;
            this.Impuesto = null;
            this.Subtotal = null;
            this.Total = null;
            this.Pedido = new Pedido();
            this.EstadoDocumento = new EstadoDocumento();
        }


        public bool Insert()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_INSERT_DOCUMENTOVENTA(
                        this.FechaEmision,
                        this.PrecioProducto,
                        this.PrecioTransporte,
                        this.Impuesto,
                        this.Subtotal,
                        this.Total,
                        this.Pedido.IdPedido,
                        this.EstadoDocumento.IdEstado
                        );
                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public bool Update()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_UPDATE_DOCUMENTOVENTA(
                        this.IdDocumento,
                        this.FechaEmision,
                        this.PrecioProducto,
                        this.PrecioTransporte,
                        this.Impuesto,
                        this.Subtotal,
                        this.Total,
                        this.Pedido.IdPedido,
                        this.EstadoDocumento.IdEstado
                        );
                    return true;

                }
             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<DocumentoVenta> ReadAll()
        {
            try
            {
                List<DocumentoVenta> listado = new List<DocumentoVenta>();
                using (var db =new DBEntities())
                {
                    var documentos = db.DOCUMENTOVENTA.ToList();
                    if(documentos.Count() > 0)
                    {
                        foreach(var doc in documentos)
                        {
                            DocumentoVenta documento = new DocumentoVenta();
                            documento.IdDocumento = (int)doc.IDDOCUMENTO;
                            documento.FechaEmision = doc.FECHAEMISION;
                            documento.PrecioProducto = doc.PRECIOPRODUCTO;
                            documento.PrecioTransporte = doc.PRECIOTRANSPORTE;
                            documento.Impuesto = doc.IMPUESTO;
                            documento.Subtotal = doc.SUBTOTAL;
                            documento.Total= doc.TOTAL;

                            int idPedido = (int)doc.PEDIDO.IDPEDIDO;
                            documento.Pedido.IdPedido = idPedido;
                            documento.Pedido.Read();

                            int idestadodoc = (int)doc.IDESTADODOC;
                            documento.EstadoDocumento.IdEstado = idestadodoc;
                            documento.EstadoDocumento.Read();

                            listado.Add(documento);
                        }
                    }

                    return listado;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<DocumentoVenta>();
            }
        }



    }
}
