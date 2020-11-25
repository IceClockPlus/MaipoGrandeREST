using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceMaipo.Controllers
{
    public class EncuestaController : ApiController
    {
        // GET: api/Encuesta
        public IEnumerable<Encuesta> Get()
        {
            try
            {
                List<Encuesta> encuestas = new List<Encuesta>();
                Encuesta encuesta = new Encuesta();
                encuestas = encuesta.ReadAll();

                return encuestas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Encuesta>();
            }

        }

        // GET: api/Encuesta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Encuesta
        public IHttpActionResult Post([FromBody]Encuesta encuesta)
        {
            try
            {
                if (encuesta.Insert())
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

        // PUT: api/Encuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Encuesta/5
        public void Delete(int id)
        {
        }
    }
}
