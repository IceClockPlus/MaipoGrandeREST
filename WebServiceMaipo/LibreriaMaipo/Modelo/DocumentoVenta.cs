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
        public Nullable<int> Total { get; set; }
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

        public bool UpdatePrecios()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_UPDATE_DOCVENTA_PRECIOS(this.IdDocumento, this.PrecioProducto, this.PrecioTransporte, this.Impuesto, this.Subtotal, this.Total);
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Obtener el documento de venta de acuerdo a la id del documento
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var doc = db.DOCUMENTOVENTA.Where(d => d.IDDOCUMENTO == this.IdDocumento).FirstOrDefault();
                    if(doc != null)
                    {
                        this.FechaEmision = doc.FECHAEMISION;
                        this.PrecioProducto = doc.PRECIOPRODUCTO;
                        this.PrecioTransporte = doc.PRECIOTRANSPORTE;
                        this.Impuesto = doc.IMPUESTO;
                        this.Subtotal = doc.SUBTOTAL;
                        this.Total = (int?)doc.TOTAL;

                        int idPedido = (int)doc.PEDIDO.IDPEDIDO;

                        this.Pedido.IdPedido = idPedido;
                        this.Pedido.Read();

                        int idestadodoc = (int)doc.IDESTADODOC;
                        this.EstadoDocumento.IdEstado = idestadodoc;
                        this.EstadoDocumento.Read();

                        return true;
                    }
                    return false;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Obtener documento de venta segun la id del pedido asociado
        /// </summary>
        /// <returns></returns>
        public bool ReadByIdPedido()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var doc = db.DOCUMENTOVENTA.Where(d => d.IDPEDIDO == this.Pedido.IdPedido).FirstOrDefault();
                    if (doc != null)
                    {
                        this.IdDocumento = (int)doc.IDDOCUMENTO;
                        this.FechaEmision = doc.FECHAEMISION;
                        this.PrecioProducto = doc.PRECIOPRODUCTO;
                        this.PrecioTransporte = doc.PRECIOTRANSPORTE;
                        this.Impuesto = doc.IMPUESTO;
                        this.Subtotal = doc.SUBTOTAL;
                        this.Total = (int?)doc.TOTAL;

                        int idPedido = (int)doc.PEDIDO.IDPEDIDO;

                        this.Pedido.IdPedido = idPedido;
                        this.Pedido.Read();

                        int idestadodoc = (int)doc.IDESTADODOC;
                        this.EstadoDocumento.IdEstado = idestadodoc;
                        this.EstadoDocumento.Read();

                        return true;
                    }
                    return false;
                }


            }
            catch (Exception ex)
            {

                throw;
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
                            documento.Total= (int?)doc.TOTAL;

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
