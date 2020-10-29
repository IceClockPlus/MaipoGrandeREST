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
        public IHttpActionResult RegistrarProduccion([FromBody]ProduccionViewModel model)
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
        public void Put(int id, [FromBody]string value)
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
