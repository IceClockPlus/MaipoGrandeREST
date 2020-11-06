using LibreriaMaipo;
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
    public class SubastaController : ApiController
    {
        // GET: api/Subasta
        public IEnumerable<Subasta> Get()
        {
            try
            {
                List<Subasta> subastas = RepositorioSubasta.ListarSubastas();
                return subastas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: api/Subasta/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Subasta subasta = new Subasta();
                subasta.IdSubasta = id;
                if (subasta.Read())
                {
                    return Ok(subasta);

                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }


        }

        [HttpGet]
        [Route("api/SubastaEstado/{idEstado}")]
        public IEnumerable<Subasta> GetSubastaPorEstado(int idEstado)
        {
            try
            {
                List<Subasta> subastas = new List<Subasta>();
                subastas = RepositorioSubasta.ListarSubastaPorEstado(idEstado);
                return subastas;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // POST: api/Subasta
        public IHttpActionResult PostSubasta([FromBody] Subasta model)
        {
            try
            {
                if (model.Agregar())
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }


        }

        // PUT: api/Subasta/5
        public IHttpActionResult Put([FromBody] Subasta model)
        {
            try
            {
                if (model.Update())
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE: api/Subasta/5
        public void Delete(int id)
        {
        }
    }
}
