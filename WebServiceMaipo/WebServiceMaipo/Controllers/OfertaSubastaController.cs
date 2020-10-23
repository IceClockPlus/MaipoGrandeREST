using LibreriaMaipo;
using LibreriaMaipo.Modelo;
using LibreriaMaipo.TiposUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMaipo.Models.WS;

namespace WebServiceMaipo.Controllers
{
    public class OfertaSubastaController : ApiController
    {
        // GET: api/OfertaSubasta
        [Route("api/BusquedaOfertaSubasta/")]
        public IEnumerable<OfertaSubasta> GetOfertaSubasta([FromBody] SecurityViewModel model)
        {
            try
            {
                Usuario usr = this.Validate(model.Token);
                if (!(usr.TipoUsuario is Transportista))
                {
                    return null;
                }

                List<OfertaSubasta> listadoOfertas = RepositorioOfertaSubasta.ListarPorIdTransportista(usr.TipoUsuario.Id);
                return listadoOfertas;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        // GET: api/OfertaSubasta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OfertaSubasta
        public IHttpActionResult RegistrarOferta([FromBody]OfertaSubastaModelView model)
        {
            try
            {
                Usuario usr = this.Validate(model.Token);
                if (!(usr.TipoUsuario is Transportista))
                {
                    return Unauthorized();
                }
                int idSubasta = model.IdSubasta;
                OfertaSubasta ofertaSubasta = new OfertaSubasta();
                ofertaSubasta.Transportista.Id = usr.TipoUsuario.Id;
                ofertaSubasta.TipoTransporte.IdTipo = model.IdTipoTransporte;
                ofertaSubasta.PrecioOferta = model.PrecioOferta;
                ofertaSubasta.FechaOferta = DateTime.Today;

                RepositorioOfertaSubasta.AgregarOfertaSubasta(ofertaSubasta, idSubasta);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
                
            }

        }

        // PUT: api/OfertaSubasta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OfertaSubasta/5
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
