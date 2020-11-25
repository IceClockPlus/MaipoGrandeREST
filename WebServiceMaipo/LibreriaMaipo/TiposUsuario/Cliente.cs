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
        /// <summary>
        /// Listar todos los clientes registrados
        /// </summary>
        /// <returns></returns>
        public override List<TipoUsuario> ReadAll()
        {
            try
            {
                List<TipoUsuario> list = new List<TipoUsuario>();
                using (var db = new DBEntities())
                {
                    var listadoCliente = db.CLIENTE.ToList();
                    if (listadoCliente.Count > 0)
                    {
                        foreach (var c in listadoCliente)
                        {
                            Cliente cli = new Cliente();
                            cli.Id = (int)c.IDCLIENTE;
                            cli.Nombre = c.NOMBRECLIENTE;
                            cli.Direccion = c.DIRECCIONCLIENTE;
                            cli.Telefono = c.TELEFONOCLIENTE;
                            cli.Correo = c.CORREO;

                            list.Add(cli);

                        }
                    }

                    return list;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<TipoUsuario>();
            }
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
                    this.Correo = clienteBuscado.CORREO;
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
        public override bool ReadById(int idUsuario)
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
                    this.Correo = clienteBuscado.CORREO;
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
