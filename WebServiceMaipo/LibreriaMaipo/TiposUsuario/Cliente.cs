using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DatoMaipo;

namespace LibreriaMaipo.TiposUsuario
{
    [DataContract]
    public class Cliente : TipoUsuario
    {
        public override List<TipoUsuario> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public override void ObtenerDatosPorId(int id)
        {
            using(var db = new DBEntities())
            {
                try
                {
                    var clienteBuscado = db.CLIENTE.Where(cli => cli.IDCLIENTE == id).FirstOrDefault();
                    this.Id = (int)clienteBuscado.IDCLIENTE;
                    this.Nombre = clienteBuscado.NOMBRECLIENTE;
                    this.Direccion = clienteBuscado.DIRECCIONCLIENTE;
                    this.Telefono = clienteBuscado.TELEFONOCLIENTE;

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        /// <summary>
        /// Buscar los datos del cliente en base a su id de usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public override bool ObtenerDatosPorIdUsuario(int idUsuario)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var clienteBuscado = db.CLIENTE.Where(cli => cli.IDUSUARIO == idUsuario).FirstOrDefault();
                    //Si no existe un cliente con la id de usuario correspondiente
                    if (clienteBuscado == null)
                    {
                        return false;
                    }
                    this.Id = (int)clienteBuscado.IDCLIENTE;
                    this.Nombre = clienteBuscado.NOMBRECLIENTE;
                    this.Direccion = clienteBuscado.DIRECCIONCLIENTE;
                    this.Telefono = clienteBuscado.TELEFONOCLIENTE;
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
