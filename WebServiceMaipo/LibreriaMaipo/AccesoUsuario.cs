using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatoMaipo;

namespace LibreriaMaipo
{
    public class AccesoUsuario
    {
        public Usuario Login(String nombreUsuario,String pass)
        {
            Usuario usuario = new Usuario();
            try
            {
                using(var db = new DBEntities())
                {
                    var usuarioBuscado = db.USUARIO.Include("ROL").
                        Where(u => u.NOMBRE_USUARIO == nombreUsuario && u.CONTRASENIA == pass).FirstOrDefault();
                    if(usuarioBuscado == null)
                    {
                        return null;
                    }

                    
                    usuario.IdUsuario = (int)usuarioBuscado.ID_USUARIO;
                    usuario.NombreUsuario = usuarioBuscado.NOMBRE_USUARIO;
                    usuario.IsHabilitado = usuarioBuscado.IS_HABILITADO;
                    usuario.NombreRol = usuarioBuscado.ROL.NOMBRE_ROL;

                    /*Si el usuario esta validado para usar el sistema, se le genera un token de acceso*/
                    if (this.VerificarHabilitado(usuario.IsHabilitado))
                    {
                        usuario.Token = Guid.NewGuid().ToString();
                        usuarioBuscado.TOKEN = usuario.Token;
                    }
                    db.Entry(usuarioBuscado).State = System.Data.EntityState.Modified;
                    db.SaveChanges();

                    
                }

                return usuario;
            }
            catch(Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }

        }


        public bool VerificarHabilitado(String habilitado)
        {
            if (habilitado.Equals("1")){ 
                return true;
            }
            return false;

        }

    }
}
