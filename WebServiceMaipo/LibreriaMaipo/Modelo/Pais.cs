using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class Pais
    {
        private int _idPais;

        private String _nombrePais;

        public int IdPais
        {
            get 
            { 
                return _idPais; 
            }
            set
            {
                _idPais = value;
            }

        }

        public String NombrePais
        {
            get
            {
                return _nombrePais;
            }
            set
            {
                _nombrePais = value;
            }
        }

        public Pais()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdPais = 0;
            this.NombrePais = String.Empty;
        }
    }
}
