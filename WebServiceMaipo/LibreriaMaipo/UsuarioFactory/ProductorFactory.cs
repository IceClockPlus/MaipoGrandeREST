using LibreriaMaipo.TiposUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.UsuarioFactory
{
    public class ProductorFactory : TipoUsuarioFactory
    {
        public override TipoUsuario createTipoUsuario()
        {
            return new Productor();
        }
    }
}
