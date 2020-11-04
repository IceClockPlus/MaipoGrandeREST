using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceMaipo.Controllers
{
    public class TipoTransporteController : ApiController
    {
        // GET: api/TipoTransporte
        public IEnumerable<TipoTransporte> ObtenerTiposTransporte()
        {
            try
            {
                List<TipoTransporte> listado = new List<TipoTransporte>();
                TipoTransporte tipo = new TipoTransporte();
                listado = tipo.ReadAll();
                return listado;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (IEnumerable<TipoTransporte>)NotFound();
            }

        }

        // GET: api/TipoTransporte/5
        public IHttpActionResult ObtenerTipoTransporte(int id)
        {
            try
            {
                TipoTransporte tipo = new TipoTransporte();
                tipo.IdTipo = id;
                if(tipo.GetById() == true)
                {
                    return Ok(tipo);
                }
                else
                {
                    return NotFound();
                }
               

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST: api/TipoTransporte
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TipoTransporte/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TipoTransporte/5
        public void Delete(int id)
        {
        }
    }
}
