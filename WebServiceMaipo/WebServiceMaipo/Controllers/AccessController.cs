using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMaipo.Models.WS;
using DatoMaipo;
using LibreriaMaipo.Modelo;
using System.Data.Entity;
using LibreriaMaipo;

namespace WebServiceMaipo.Controllers
{
    public class AccessController : ApiController
    {
        public IHttpActionResult Login([FromBody]AccessViewModel model)
        {
            try
            {
                Usuario usuario = new Usuario();
                AccesoUsuario access = new AccesoUsuario();

                usuario = access.Login(model.NombreUsuario, model.Contrasenia);
                if(usuario == null)
                {
                    return Unauthorized();
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return InternalServerError();
            }
            
        }

        

    }
}
