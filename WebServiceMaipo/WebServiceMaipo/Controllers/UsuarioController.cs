using LibreriaMaipo;
using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceMaipo.Controllers
{
    public class UsuarioController : ApiController
    {
        public IEnumerable<Usuario> get()
        {
            var list = RepositorioUsuario.listar();
            return list;
        }

    }
}
