using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    /// <summary>
    /// Modelo con el que se van a autentica a los usuarios
    /// </summary>
    public class AccessViewModel
    {
        public String nombreUsuario { get; set; }
        public String contrasenia { get; set; }
    }
}