using DatoMaipo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LibreriaMaipo
{
    public class Productor : TipoUsuario
    {
        public override void ObtenerDatosPorId(int id)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    var productor = db.PRODUCTOR.FirstOrDefault(prod => prod.IDPRODUCTOR == id);
                    if(productor != null)
                    {
                        this.Id = (int)productor.IDPRODUCTOR;
                        this.Nombre = productor.NOMBREPRODUCTOR;
                        this.Direccion = productor.DIRECCIONPRODUCTOR;
                        this.Telefono = productor.TELEFONOPRODUCTRO;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        /// <summary>
        /// Obtener los datos del productor en base a la id de usuario de este
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public override bool ReadById(int idUsuario)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var prodBuscado = db.PRODUCTOR.Where(productor => productor.IDUSUARIO == idUsuario).FirstOrDefault();
                    if (prodBuscado == null)
                    {
                        return false;
                    }

                    /*Los campos de la instancia se asignan los valores recuperados de la base de datos*/
                    this.Id = (int)prodBuscado.IDPRODUCTOR;
                    this.Nombre = prodBuscado.NOMBREPRODUCTOR;
                    this.Direccion = prodBuscado.DIRECCIONPRODUCTOR;
                    this.Telefono = prodBuscado.TELEFONOPRODUCTRO;

                    return true;

                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Listar todos los productores registrados
        /// </summary>
        /// <returns></returns>
        public override List<TipoUsuario> ReadAll()
        {
            try
            {
                List<TipoUsuario> listado = new List<TipoUsuario>();

                using (var db = new DBEntities())
                {
                    var query = db.PRODUCTOR.ToList();

                    foreach (var pro in query)
                    {
                        Productor productor = new Productor();

                        /*Los campos de la instancia se asignan los valores recuperados de la base de datos*/
                        productor.Id = (int)pro.IDPRODUCTOR;
                        productor.Nombre = pro.NOMBREPRODUCTOR;
                        productor.Direccion = pro.DIRECCIONPRODUCTOR;
                        productor.Telefono = pro.TELEFONOPRODUCTRO;
                        listado.Add(productor);

                    }
                    return listado;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<TipoUsuario>();
            }
        }

    }
}