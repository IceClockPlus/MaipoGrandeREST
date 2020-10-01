using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class Usuario
    {
        private int _idUsuario;

        private String _nombreUsuario;

        private String _contrasenia;

        private String _isHabilitado;

        private String _token;

        private String _nombreRol;

        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }
        }

        public String NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }

        public String Contrasenia
        {
            get
            {
                return _contrasenia;
            }
            set
            {
                _contrasenia = value;
            }
        }

        public String IsHabilitado
        {
            get
            {
                return _isHabilitado;
            }
            set
            {
                _isHabilitado = value;
            }
        }

        public String Token
        {
            get { return _token; }
            set { _token = value; }
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

        public Usuario()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdUsuario = 0;
            this.NombreUsuario = String.Empty;
            this.Contrasenia = String.Empty;
            this.IsHabilitado = "0";
            this.Token = String.Empty;
            this.NombreRol = String.Empty;
        }
    }
}
