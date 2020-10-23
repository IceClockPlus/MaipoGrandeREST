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
        public string Get(int id)
        {
            return "value";
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
        public IHttpActionResult PostSubasta([FromBody] SubastaViewModel model)
        {
            try
            {
                //Asignacion de valores
                Subasta subasta = new Subasta();
                subasta.FechaInicio = model.FechaInicio;
                subasta.FechaTermino = model.FechaTermino;
                subasta.Pedido.IdPedido = model.IdPedido;

                RepositorioSubasta.Agregar(subasta);
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }


        }

        // PUT: api/Subasta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Subasta/5
        public void Delete(int id)
        {
        }
    }
}
