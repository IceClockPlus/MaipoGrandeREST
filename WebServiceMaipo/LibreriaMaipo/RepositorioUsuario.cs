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
                var ls = db.USUARIO.ToList();
                foreach(var x in ls)
                {
                    Usuario u = new Usuario();
                    u.IdUsuario = (int)x.ID_USUARIO;
                    u.NombreUsuario = x.NOMBRE_USUARIO;
                    u.Contrasenia = x.CONTRASENIA;
                    u.IsHabilitado = x.IS_HABILITADO;
                    u.IdRol = (int)x.ID_ROL;
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
                var u = db.USUARIO.Where(x => x.ID_USUARIO == id).FirstOrDefault();

                if (u == null)
                {
                    return null;
                }

                user.IdUsuario = (int)u.ID_USUARIO;
                user.NombreUsuario = u.NOMBRE_USUARIO;
                user.Contrasenia = u.CONTRASENIA;
                user.IsHabilitado = u.IS_HABILITADO;
                user.IdRol = (int)u.ID_ROL;


            }
            return user;
        }



    }
}
