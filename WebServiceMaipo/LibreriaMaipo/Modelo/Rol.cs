using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class Rol
    {
        private int _idRol;

        private String _nombreRol;

        public int IdRol
        {
            get
            {
                return _idRol;
            }
            set
            {
                _idRol = value;
            }
        }

        public String NombreRol
        {
            get
            {
                return _nombreRol;
            }
            set
            {
                _nombreRol = value;
            }
        }

        public Rol()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdRol = 0;
            this.NombreRol = String.Empty;
        }
    }
}
