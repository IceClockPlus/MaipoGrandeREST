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
        /// <summary>
        /// Listar todos los transportistas registrados
        /// </summary>
        /// <returns></returns>
        public override List<TipoUsuario> ReadAll()
        {
            try
            {
                List<TipoUsuario> list = new List<TipoUsuario>();
                using (var db = new DBEntities())
                {
                    var listadoTransportista = db.TRANSPORTISTA.ToList();
                    if (listadoTransportista.Count > 0)
                    {
                        foreach(var t in listadoTransportista)
                        {
                            Transportista trans = new Transportista();
                            trans.Id = (int)t.IDTTRANSPORTISTA;
                            trans.Nombre = t.NOMBRETRANSPORTISTA;
                            trans.Direccion = t.DIRECCIONTRANSPORTISTA;
                            trans.Telefono = t.TELEFONOTRANSPORTISTA;
                            this.Correo = t.CORREO;
                            list.Add(trans);

                        }
                    }

                    return list;

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<TipoUsuario>();
            }

        }

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
                    this.Correo = tran.CORREO;

                }catch(Exception ex)
                {
                    ex.InnerException.ToString();

                }


            }
        }

        public override bool ReadById(int idUsuario)
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
                    this.Correo = tran.CORREO;
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
