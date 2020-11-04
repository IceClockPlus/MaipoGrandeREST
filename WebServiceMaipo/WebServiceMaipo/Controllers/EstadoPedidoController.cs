using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceMaipo.Controllers
{
    public class EstadoPedidoController : ApiController
    {
        [HttpGet]
        // GET: api/EstadoPedido
        public IEnumerable<EstadoPedido> ObtenerEstadosPedido()
        {
            try
            {
                List<EstadoPedido> list = new List<EstadoPedido>();
                EstadoPedido estado = new EstadoPedido();
                list = estado.ReadAll();
                return list;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EstadoPedido>();
            }
            
        }

        // GET: api/EstadoPedido/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EstadoPedido
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EstadoPedido/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EstadoPedido/5
        public void Delete(int id)
        {
        }
    }
}
