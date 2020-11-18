using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DocumentoVenta
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DocumentoVenta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DocumentoVenta/5
        public void Delete(int id)
        {
        }
    }
}
