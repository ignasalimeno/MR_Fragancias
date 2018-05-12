using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidosMuestra
    {
        public int idPedidoMuestra;
        public int idCliente;
        public int idContacto;
        public string Vendedor;
        public DateTime FechaEntregaCliente;
        public string ProductoFinal;
        public DateTime FechaSolicitud;
        public bool Aplicacion;
        public bool BaseCliente;
        public double Costo;
        public double Gramos;
        public List<PedidosMuestra_Fragancias> fragancias;

        public int guardarPedidoMuestra(PedidosMuestra miPedido)
        {
            try
            {
                miPedido.idPedidoMuestra = int.Parse(AccesoADatos.connectToDB.readOneField("Select case when MAX(idpedidomuestra) IS null then 1 else MAX(idpedidomuestra) + 1 end from MRFragancias.dbo.PedidosMuestra"));

                string str = "INSERT INTO [MRFragancias].[dbo].[PedidosMuestra] ";
                str = str + "VALUES (";
                str = str + miPedido.idPedidoMuestra + ", ";
                str = str + miPedido.idCliente + ", ";
                str = str + miPedido.idContacto == "0" ? "'NULL'" : str + miPedido.idContacto + ", ";
                str = str + "'" + miPedido.Vendedor + "', ";
                str = str + "'" + convertirAFechaEnIngles( miPedido.FechaEntregaCliente) + "', ";
                str = str + "'" + miPedido.ProductoFinal + "', ";
                str = str + "'" + convertirAFechaEnIngles( miPedido.FechaSolicitud) + "', ";
                str = str + (miPedido.Aplicacion ? "1" : "0") + ", ";
                str = str + (miPedido.BaseCliente ? "1" : "0") + ", ";
                str = str + miPedido.Costo + ", ";
                str = str + miPedido.Gramos + ")";

                AccesoADatos.connectToDB.launchCommand(str);

                return miPedido.idPedidoMuestra;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public string convertirAFechaEnIngles(DateTime date)
        {
            try
            {
                string nuevaFecha = date.Month + "/" + date.Day + "/" + date.Year;
                return nuevaFecha;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public bool borrarPedidoMuestraFragancias(int idPedidoMuestra)
        {
            try
            {
                string str = "DELETE FROM MRFragancias..PedidosMuestra_Fragancias WHERE idPedidoMuestra = " + idPedidoMuestra.ToString();

                AccesoADatos.connectToDB.launchCommand(str);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool actualizarPedidoMuestra(PedidosMuestra miPedido)
        {
            try
            {
                string str = "";
                str = str + "UPDATE [MRFragancias].[dbo].[PedidosMuestra] ";
                str = str + "SET ";
                str = str + "      [idCliente] = " + miPedido.idCliente.ToString();
                str = str + "      ,[idContacto] = " + miPedido.idContacto == "0" ? "'NULL'" : str + ",[idContacto] = " + miPedido.idContacto.ToString();
                str = str + "      ,[Vendedor] = '" + miPedido.Vendedor.ToString() + "'";
                str = str + "      ,[FechaEntregaCliente] = '" + miPedido.FechaEntregaCliente.ToShortDateString() + "'";
                str = str + "      ,[ProductoFinal] = '" + miPedido.ProductoFinal.ToString() + "'";
                str = str + "      ,[FechaSolicitud] = '" + miPedido.FechaSolicitud.ToShortDateString() + "'";
                str = str + "      ,[Aplicacion] = " + (miPedido.Aplicacion ? "1" : "0");
                str = str + "      ,[BaseCliente] = " + (miPedido.BaseCliente ? "1" : "0");
                str = str + "      ,[Costo] = " + miPedido.Costo.ToString();
                str = str + "      ,[Gramos] = " + miPedido.Gramos.ToString();
                str = str + " WHERE idPedidoMuestra = " + miPedido.idPedidoMuestra.ToString();

                AccesoADatos.connectToDB.launchCommand(str);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool borrarPedidoMuestra(int idPedidoMuestra)
        {
            try
            {
                string str = "DELETE from PedidosMuestra where idPedidoMuestra = " + idPedidoMuestra.ToString();

                AccesoADatos.connectToDB.launchCommand(str);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public DataTable getPedidoMuestraReporte(int idPedidoMuestra)
        {
            try
            {
                DataTable dt = AccesoADatos.connectToDB.fillTableSQL("EXEC [dbo].[Reporte_PedidosMuestra] @idPedidoMuestra = " + idPedidoMuestra.ToString());

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable getPedidoMuestraReporte_PorCliente(int idCliente, string fechaDesde, string fechaHasta, bool Presentada, bool Vendida)
        {
            try
            {
              
                string str = "";
                str = str + "EXEC [dbo].[Reporte_PorCliente] ";
                str = str + "@idCliente = "+ idCliente.ToString() +", ";
                str = str + "@fechaDesde = '" + fechaDesde.ToString() + "', ";
                str = str + "@fechaHasta = '" + fechaHasta.ToString() + "', ";
                
                if (Presentada)
                {
                    str = str + "@presentada = 1, ";
                }
                else
                {
                    str = str + "@presentada = 0, ";
                }
                if (Vendida)
                {
                    str = str + "@vendida = 1 ";
                }
                else
                {
                    str = str + "@vendida = 0 ";
                }
                
                DataTable dt = AccesoADatos.connectToDB.fillTableSQL(str);

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable getPedidoMuestraReporte_PorFragancia(int idFragancia, string fechaDesde, string fechaHasta, bool Presentada, bool Vendida)
        {
            try
            {

                string str = "";
                str = str + "EXEC [dbo].[Reporte_PorFragancia] ";
                str = str + "@idFragancia = " + idFragancia.ToString() + ", ";
            
                    str = str + "@fechaDesde = '" + fechaDesde.ToString() + "', ";
               
                    str = str + "@fechaHasta = '" + fechaHasta.ToString() + "', ";
                
                if (Presentada)
                {
                    str = str + "@presentada = 1, ";
                }
                else
                {
                    str = str + "@presentada = 0, ";
                }
                if (Vendida)
                {
                    str = str + "@vendida = 1 ";
                }
                else
                {
                    str = str + "@vendida = 0 ";
                }

                DataTable dt = AccesoADatos.connectToDB.fillTableSQL(str);

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable obtenerPedidosTODOS()
        {
            try
            {
                DataTable dt = new DataTable();

                string str = "SELECT PM.idPedidoMuestra, " +
                    "C.RazonSocial AS Cliente, " +
                    "CO.Nombre AS Contacto, " +
                    "PM.Vendedor, " +
                    "PM.FechaSolicitud as [Fecha de Solicitud] " +
                "FROM MRFragancias..PedidosMuestra PM " +
                "INNER JOIN MRFragancias..Clientes C ON PM.idCliente = C.idCliente " +
                "INNER JOIN MRFragancias..Contactos CO ON PM.idContacto = CO.idContacto";

                dt = AccesoADatos.connectToDB.fillTableSQL(str);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable obtenerPedidosPorId(string idPedidoMuestra)
        {
            try
            {
                DataTable dt = new DataTable();

                string str = "SELECT PM.idPedidoMuestra, " +
                    "C.RazonSocial AS Cliente, " +
                    "CO.Nombre AS Contacto, " +
                    "PM.Vendedor, " +
                    "PM.FechaSolicitud as [Fecha de Solicitud] " +
                "FROM MRFragancias..PedidosMuestra PM " +
                "INNER JOIN MRFragancias..Clientes C ON PM.idCliente = C.idCliente " +
                "INNER JOIN MRFragancias..Contactos CO ON PM.idContacto = CO.idContacto " +
                "WHERE PM.idPedidoMuestra = " + idPedidoMuestra;

                dt = AccesoADatos.connectToDB.fillTableSQL(str);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable obtenerPedidosPorCliente(int idCliente)
        {
            try
            {
                DataTable dt = new DataTable();

                string str = "SELECT PM.idPedidoMuestra, " +
                     "C.RazonSocial AS Cliente, " +
                     "CO.Nombre AS Contacto, " +
                     "PM.Vendedor, " +
                     "PM.FechaSolicitud as [Fecha de Solicitud] " +
                 "FROM MRFragancias..PedidosMuestra PM " +
                 "INNER JOIN MRFragancias..Clientes C ON PM.idCliente = C.idCliente " +
                 "INNER JOIN MRFragancias..Contactos CO ON PM.idContacto = CO.idContacto " +
                 "WHERE PM.idCliente = " + idCliente.ToString();

                dt = AccesoADatos.connectToDB.fillTableSQL(str);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable obtenerPedidosPorVendedor(string NombreVendedor)
        {
            try
            {
                DataTable dt = new DataTable();

                string str = "SELECT PM.idPedidoMuestra, " +
                    "C.RazonSocial AS Cliente, " +
                    "CO.Nombre AS Contacto, " +
                    "PM.Vendedor, " +
                    "PM.FechaSolicitud as [Fecha de Solicitud] " +
                "FROM MRFragancias..PedidosMuestra PM " +
                "INNER JOIN MRFragancias..Clientes C ON PM.idCliente = C.idCliente " +
                "INNER JOIN MRFragancias..Contactos CO ON PM.idContacto = CO.idContacto " +
                "WHERE PM.Vendedor like '%" + NombreVendedor + "%'";

                dt = AccesoADatos.connectToDB.fillTableSQL(str);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable obtenerPedidosPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                DataTable dt = new DataTable();

                string str = "SELECT PM.idPedidoMuestra, " +
                    "C.RazonSocial AS Cliente, " +
                    "CO.Nombre AS Contacto, " +
                    "PM.Vendedor, " +
                    "PM.FechaSolicitud as [Fecha de Solicitud] " +
                "FROM MRFragancias..PedidosMuestra PM " +
                "INNER JOIN MRFragancias..Clientes C ON PM.idCliente = C.idCliente " +
                "INNER JOIN MRFragancias..Contactos CO ON PM.idContacto = CO.idContacto " +
                "WHERE PM.FechaSolicitud >= '" + fechaDesde + "' and PM.FechaSolicitud <= '" + fechaHasta + "'";

                dt = AccesoADatos.connectToDB.fillTableSQL(str);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PedidosMuestra get1PedidoMuestra(int idPedidoMuestra)
        {
            try
            {
                PedidosMuestra _miPedido = new PedidosMuestra();

                DataTable dtPM = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[PedidosMuestra] WHERE idPedidoMuestra = " + idPedidoMuestra.ToString());

                if (dtPM.Rows.Count > 0)
                {
                    _miPedido.idPedidoMuestra = int.Parse(dtPM.Rows[0]["idPedidoMuestra"].ToString());
                    _miPedido.idCliente = int.Parse(dtPM.Rows[0]["idCliente"].ToString());
                    _miPedido.idContacto = int.Parse(dtPM.Rows[0]["idContacto"].ToString());
                    _miPedido.Vendedor = dtPM.Rows[0]["Vendedor"].ToString();
                    _miPedido.FechaEntregaCliente = DateTime.Parse(dtPM.Rows[0]["FechaEntregaCliente"].ToString());
                    _miPedido.ProductoFinal = dtPM.Rows[0]["ProductoFinal"].ToString();
                    _miPedido.FechaSolicitud = DateTime.Parse(dtPM.Rows[0]["FechaSolicitud"].ToString());
                    _miPedido.Aplicacion = dtPM.Rows[0]["Aplicacion"].ToString() == "1" ? true : false;
                    _miPedido.BaseCliente = dtPM.Rows[0]["BaseCliente"].ToString() == "1" ? true : false;
                    _miPedido.Costo = double.Parse(dtPM.Rows[0]["Costo"].ToString());
                    _miPedido.Gramos = double.Parse(dtPM.Rows[0]["Gramos"].ToString());

                    PedidosMuestra_Fragancias _miPedidoMuestraFrag = new PedidosMuestra_Fragancias();

                    _miPedido.fragancias = _miPedidoMuestraFrag.getFraganciasFromPedidoMuestra(_miPedido.idPedidoMuestra);
                }
                else
                {
                    throw new Exception();
                }

                return _miPedido;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
