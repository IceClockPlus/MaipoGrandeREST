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
    public class ProduccionController : ApiController
    {
        [HttpGet]
        public IEnumerable<Produccion>ObtenerProduccion(int idProductor)
        {
            try
            {
                List<Produccion> list = new List<Produccion>();
                list = RepositorioProduccion.ObtenerPorIdProductor(idProductor);
                return list;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (IEnumerable<Produccion>)NotFound();
            }

        }

        [HttpGet]
        [Route("api/Produccion/")]
        public IEnumerable<Produccion> ObtenerProduccion()
        {
            try
            {
                List<Produccion> list = new List<Produccion>();
                Produccion produccion = new Produccion();
                list = produccion.ReadAll();
                return list;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (IEnumerable<Produccion>)NotFound();
            }

        }

        [HttpGet]
        [Route("api/ProduccionProductor/")]
        public IEnumerable<Produccion> ObtenerProduccionProductor(SecurityViewModel model)
       {
            try
            {
                Usuario user = this.Validate(model.Token);

                List<Produccion> listadoProduccion = new List<Produccion>();
                listadoProduccion = RepositorioProduccion.ObtenerPorIdProductor(user.TipoUsuario.Id);
                return listadoProduccion;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

   

        // POST: api/Produccion
        [HttpPost]
        [Route("api/ProduccionPost")]
        public IHttpActionResult Post([FromBody]ProduccionViewModel model)
        {
            try
            {
                Usuario user = this.Validate(model.Token);
                Produccion produccion = new Produccion();
                produccion.IdProductor = user.TipoUsuario.Id;
                produccion.PrecioEstandar = model.PrecioEstandar;
                produccion.PrecioLower = model.PrecioLower;
                produccion.PrecioPremium = model.PrecioPremium;
                produccion.Producto.IdProducto = model.IdProducto;
                if(RepositorioProduccion.AgregarProduccion(produccion) == false)
                {
                    return BadRequest();
                }
                return Ok();

            }
            catch (Exception ex)
            {

                return InternalServerError();
            }


        }

        // PUT: api/Produccion/5
        public void Put(int id, [FromBody]ProduccionViewModel model)
        {
        }

        // DELETE: api/Produccion/5
        public void Delete(int id)
        {
        }

        public Usuario Validate(string token)
        {
            Usuario user = RepositorioUsuario.GetUsuarioByToken(token);
            return user;
        }

    }
}
