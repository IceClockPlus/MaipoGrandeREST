using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMaipo.Models.WS;

namespace WebServiceMaipo.Controllers
{
    public class LogoutController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Logout([FromBody] SecurityViewModel model)
        {
            using (DBEntities db = new DBEntities())
            {
                var lst = db.USUARIO.Where(x => x.TOKEN == model.Token);
                if (lst.Count() > 0)
                {
                    USUARIO usr = lst.First();
                    usr.TOKEN = String.Empty;
                    db.Entry(usr).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    return Unauthorized();
                }

            }
            return Ok();
        }
    }
}
