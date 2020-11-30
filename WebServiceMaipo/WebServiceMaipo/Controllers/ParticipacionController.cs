using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceMaipo.Controllers
{
    public class ParticipacionController : ApiController
    {
        // GET: api/Participacion
        /// <summary>
        /// Mostrar todas las participaciones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Participacion> Get()
        {

            try
            {
                List<Participacion> listado = new List<Participacion>();
                Participacion participacion = new Participacion();
                listado = participacion.ReadAll();
                return listado;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Participacion>();
            }
            
        }

        [HttpGet]
        [Route("api/ParticipacionProductor")]
        public IEnumerable<Participacion> GetParticipacionesProductor()
        {

            try
            {
                List<Participacion> listado = new List<Participacion>();
                Participacion participacion = new Participacion();
                listado = participacion.ReadAll();
                return listado;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Participacion>();
            }

        }

        [HttpGet]
        [Route("api/ParticipacionPedido/{id}")]
        public IEnumerable<Participacion> GetParticipacionesPedido(int id)
        {

            try
            {
                List<Participacion> listado = new List<Participacion>();
                Participacion participacion = new Participacion();
                participacion.Pedido.IdPedido = id;
                listado = participacion.ReadByIdPedido();
                return listado;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Participacion>();
            }

        }


        // GET: api/Participacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Participacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Participacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Participacion/5
        public void Delete(int id)
        {
        }
    }
}
