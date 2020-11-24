using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMaipo.Models.WS;

namespace WebServiceMaipo.Controllers
{
    public class DocumentoVentaController : ApiController
    {
        // GET: api/DocumentoVenta
        public IEnumerable<DocumentoVenta> Get()
        {
            try
            {
                List<DocumentoVenta> list = new List<DocumentoVenta>();
                DocumentoVenta documento = new DocumentoVenta();
                list = documento.ReadAll();

                return list;

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return new List<DocumentoVenta>();
            }


        }

        // GET: api/DocumentoVenta/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                DocumentoVenta documentoVenta = new DocumentoVenta();
                documentoVenta.IdDocumento = id;
                if (documentoVenta.Read())
                {
                    return Ok(documentoVenta);

                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }


        }

        [HttpGet]
        [Route("api/DocumentoVentaPedido/{idPedido}")]
        public IHttpActionResult GetByIdPedido(int idPedido)
        {
            try
            {
                DocumentoVenta documentoVenta = new DocumentoVenta();
                documentoVenta.Pedido.IdPedido = idPedido;
                if (documentoVenta.ReadByIdPedido())
                {
                    return Ok(documentoVenta);
                }
                else
                {
                    return NotFound();
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        // POST: api/DocumentoVenta
        public IHttpActionResult Post([FromBody]DocumentoVenta documento)
        {
            try
            {
                if (documento.Insert())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }

        }

        // PUT: api/DocumentoVenta/
        public IHttpActionResult Put([FromBody] DocumentoVenta documento)
        {
            try
            {
                if (documento.Update())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        // DELETE: api/DocumentoVenta/5
        public void Delete(int id)
        {
        }

        [HttpPatch]
        public IHttpActionResult Patch([FromBody] DocumentoVentaPatch documento)
        {
            try
            {
                DocumentoVenta documentoVenta = new DocumentoVenta();

                documentoVenta.Pedido.IdPedido = documento.IdPedido;
                if (documentoVenta.ReadByIdPedido())
                {
                    documentoVenta.PrecioTransporte = documento.PrecioTransporte;
                    documentoVenta.PrecioProducto = documento.PrecioProducto;
                    documentoVenta.Impuesto = documento.Impuesto;
                    documentoVenta.Subtotal = documento.Subtotal;
                    documento.Total = documento.Total;
                    if (documentoVenta.UpdatePrecios())
                    {
                        return Ok();
                    }else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }

        }
       

    }
}
