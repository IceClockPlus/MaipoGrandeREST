using DatoMaipo;
using LibreriaMaipo.Modelo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class RepositorioUsuario
    {
        public static Usuario GetUsuarioByToken(String token)
        {
            Usuario user = new Usuario();
            try
            {
                using (var db = new DBEntities())
                {
                    var userDb = db.USUARIO.Include("ROL").Where(u => u.TOKEN == token).FirstOrDefault();
                    if (userDb == null)
                    {
                        return null;
                    }

                    user.IdUsuario = (int)userDb.ID_USUARIO;
                    user.NombreUsuario = userDb.NOMBRE_USUARIO;
                    user.IsHabilitado = userDb.IS_HABILITADO;
                    user.NombreRol = userDb.ROL.NOMBRE_ROL;
                    user.TipoUsuario = GetTipoUsuario(user.NombreRol, user.IdUsuario);
                }
                return user;


            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public static List<Usuario> ListarTodosUsuario()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();
            try
            {
                using (var db = new DBEntities())
                {
                    var list = db.USUARIO.Include("ROL").ToList();

                    foreach (var usrdb in list)
                    {
                        Usuario usr = new Usuario();
                        usr.IdUsuario = (int)usrdb.ID_USUARIO;
                        usr.NombreUsuario = usrdb.NOMBRE_USUARIO;
                        usr.IsHabilitado = usrdb.IS_HABILITADO;
                        usr.Token = usrdb.TOKEN;
                        usr.NombreRol = usrdb.ROL.NOMBRE_ROL;
                        usr.TipoUsuario = GetTipoUsuario(usr.NombreRol, usr.IdUsuario);

                        listadoUsuarios.Add(usr);
                    }
                }
                return listadoUsuarios;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static TipoUsuario GetTipoUsuario(string rol, int idUsr)
        {
            TipoUsuario tipoUsuario;
            TipoUsuarioFactory factory;

            try
            {
                switch (rol)
                {
                    case "Cliente":
                        factory = new ClienteFactory();
                        tipoUsuario = factory.createTipoUsuario();
                        tipoUsuario.ObtenerDatosPorIdUsuario(idUsr);
                        break;
                    case "Productor":
                        factory = new ProductorFactory();
                        tipoUsuario = factory.createTipoUsuario();
                        tipoUsuario.ObtenerDatosPorIdUsuario(idUsr);
                        break;
                    default:
                        tipoUsuario = null;
                        break;
                }
                return tipoUsuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
