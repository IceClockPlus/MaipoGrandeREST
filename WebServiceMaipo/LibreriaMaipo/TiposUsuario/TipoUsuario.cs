using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.TiposUsuario
{
    public abstract class TipoUsuario
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }

        public TipoUsuario()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.Id = 0;
            this.Nombre = String.Empty;
            this.Direccion = String.Empty;
            this.Telefono = String.Empty;
        }

        public abstract bool GetDatosByIdUsuario(int idUsuario);
        
    }
}
