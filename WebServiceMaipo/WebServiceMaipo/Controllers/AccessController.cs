using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMaipo.Models.WS;
using DatoMaipo;

namespace WebServiceMaipo.Controllers
{
    public class AccessController : ApiController
    {
        public Reply Login([FromBody]AccessViewModel model)
        {
            Reply reply = new Reply();
            reply.result = 0;

            try
            {
                using(DBEntities db = new DBEntities())
                {
                    //Buscar usuario cuyo nombre y contraseña coincidan
                    var lst = db.USUARIO.Where(x => 
                    x.NOMBRE_USUARIO == model.nombreUsuario && x.CONTRASENIA == model.contrasenia);

                    //Revisar si existe el usuario
                    if (lst.Count() > 0)
                    {
                        reply.result = 1;
                        //Generar token
                        reply.data = Guid.NewGuid().ToString();

                        //Obtener usuario
                        USUARIO usr = lst.First();
                        //Ingresar el token generado en el usuario
                        usr.TOKEN = (String)reply.data;
                        //Se realiza la modificación
                        db.Entry(usr).State = System.Data.EntityState.Modified;
                        //Confirmación del cambio
                        db.SaveChanges();
                    }
                    else
                    {
                        reply.message = "Usuario o contraseña incorrecto";
                    }

                }

            }
            catch (Exception ex)
            {

                reply.message = "Ocurrio un error inesperado";
            }
            return reply;
        }

    }
}
