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
    class Productor : TipoUsuario
    {
        public override void ObtenerDatosPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtener los datos del productor en base a la id de usuario de este
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public override bool ObtenerDatosPorIdUsuario(int idUsuario)
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
    }
}