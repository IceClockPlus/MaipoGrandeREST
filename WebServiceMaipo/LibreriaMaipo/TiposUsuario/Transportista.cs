using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.TiposUsuario
{
    public class Transportista : TipoUsuario
    {
        public override void ObtenerDatosPorId(int id)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    TRANSPORTISTA tran = new TRANSPORTISTA();
                    tran = db.TRANSPORTISTA.Where(tr => tr.IDTTRANSPORTISTA == id).FirstOrDefault();
                    this.Id = (int)tran.IDTTRANSPORTISTA;
                    this.Nombre = tran.NOMBRETRANSPORTISTA;
                    this.Direccion = tran.DIRECCIONTRANSPORTISTA;
                    this.Telefono = tran.TELEFONOTRANSPORTISTA;

                }catch(Exception ex)
                {
                    ex.InnerException.ToString();

                }


            }
        }

        public override bool ObtenerDatosPorIdUsuario(int idUsuario)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    TRANSPORTISTA tran = new TRANSPORTISTA();
                    tran = db.TRANSPORTISTA.Where(tr => tr.IDUSUARIO == idUsuario).FirstOrDefault();
                    this.Id = (int)tran.IDTTRANSPORTISTA;
                    this.Nombre = tran.NOMBRETRANSPORTISTA;
                    this.Direccion = tran.DIRECCIONTRANSPORTISTA;
                    this.Telefono = tran.TELEFONOTRANSPORTISTA;
                    return true; 
                }
                catch (Exception ex)
                {
                    ex.InnerException.ToString();
                    return false;
                }


            }

        }
    }
}
