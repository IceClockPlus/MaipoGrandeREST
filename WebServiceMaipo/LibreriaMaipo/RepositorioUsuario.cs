using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatoMaipo;

namespace LibreriaMaipo
{
    public class RepositorioUsuario
    {
        public static List<Usuario> listar()
        {
            var lista = new List<Usuario>();
            using(DBEntities db = new DBEntities())
            {
                //Obtener los datos de la tabla Usuario, incluido los de Rol
                var ls = db.USUARIO.Include("ROL");
                foreach(var x in ls)
                {
                    Usuario u = new Usuario();
                    u.IdUsuario = (int)x.ID_USUARIO;
                    u.NombreUsuario = x.NOMBRE_USUARIO;
                    u.Contrasenia = x.CONTRASENIA;
                    u.IsHabilitado = x.IS_HABILITADO;
                    u.Rol.IdRol = (int)x.ID_ROL;
                    u.Rol.NombreRol = x.ROL.NOMBRE_ROL;
                    lista.Add(u);
                }

            }

            return lista;

        }
        
        
        public static Usuario buscarId(int id)
        {
            Usuario user = new Usuario();
            using(var db = new DBEntities())
            {
                
                var u = db.USUARIO.Include("ROL").Where(x => x.ID_USUARIO == id).FirstOrDefault();

                if (u == null)
                {
                    return null;
                }

                user.IdUsuario = (int)u.ID_USUARIO;
                user.NombreUsuario = u.NOMBRE_USUARIO;
                user.Contrasenia = u.CONTRASENIA;
                user.IsHabilitado = u.IS_HABILITADO;
                user.Rol.IdRol = (int)u.ID_ROL;
                user.Rol.NombreRol = u.ROL.NOMBRE_ROL;


            }
            return user;
        }
        


    }
}
