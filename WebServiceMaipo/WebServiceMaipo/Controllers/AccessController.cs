using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMaipo.Models.WS;
using DatoMaipo;
using LibreriaMaipo.Modelo;

namespace WebServiceMaipo.Controllers
{
    public class AccessController : ApiController
    {
        public IHttpActionResult Login([FromBody]AccessViewModel model)
        {
            Reply reply = new Reply();
            Usuario usuario = new Usuario();

            try
            {
                using(DBEntities db = new DBEntities())
                {
                    //Buscar usuario cuyo nombre y contraseña coincidan
                    var lst = db.USUARIO.Include("ROL").Where(x => 
                    x.NOMBRE_USUARIO == model.NombreUsuario && x.CONTRASENIA == model.Contrasenia);

                    //Revisar si existe el usuario
                    if (lst.Count() > 0)
                    {

                        //Obtener usuario de la consulta
                        USUARIO usr = lst.First();
                        //Creacion de objeto usuario con los de usr
                        usuario.IdUsuario = (int)usr.ID_USUARIO;
                        usuario.NombreUsuario = usr.NOMBRE_USUARIO;
                        usuario.IsHabilitado = usr.IS_HABILITADO;
                        usuario.Token = Guid.NewGuid().ToString();
                        usuario.NombreRol = usr.ROL.NOMBRE_ROL;
                        reply.Data = usuario;

                        //Ingresar el token generado en el usuario
                        usr.TOKEN = usuario.Token;
                        //Se realiza la modificación
                        db.Entry(usr).State = System.Data.EntityState.Modified;
                        //Confirmación del cambio
                        db.SaveChanges();
                    }
                    else
                    {
                        return Unauthorized();
                    }

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return Ok(usuario);
        }

        

    }
}
