
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Fragancia
    {
        public int idFragancia;
        public string NombreReal;
        public string NombreVenta;
        public int idFamiliaOlfativa;
        public string DescOlfativa_NotaSalida;
        public string DescOlfativa_NotaMedia;
        public string DescOlfativa_NotaFondo;
        public DateTime? FechaPedidoStock;
        public int idEstado;
        public DateTime FechaIngreso;
        public string ContratipoNombre;
        public string ContratipoMarca;
        public string ContratipoAño;
        public string Equivalencia;
        public long Identificador;
        public bool Activo;

        public float Costo;
        public DateTime? FechaActCosto;


        public DataTable obtenerTodos()
        {
            try
            {
                DataTable dt = new DataTable();
                string str = "";
                str = str + "SELECT [idFragancia]";
                str = str + "      ,[NombreReal]";
                str = str + "      ,[NombreVenta]";
                str = str + "      ,F.[idFamiliaOlfativa]";
                str = str + "      ,FO.Nombre AS FamiliaOlfativa";
                str = str + "      ,[DescOlfativa_NotaSalida]";
                str = str + "      ,[DescOlfativa_NotaMedia]";
                str = str + "      ,[DescOlfativa_NotaFondo]";
                str = str + "      ,[FechaPedidoStock]";
                str = str + "      ,F.[idEstado]";
                str = str + "      ,E.Estado";
                str = str + "      ,[FechaIngreso]";
                str = str + "      ,[ContratipoNombre]";
                str = str + "      ,[ContratipoMarca]";
                str = str + "      ,[ContratipoAño]";
                str = str + "      ,[Equivalencia]";
                str = str + "      ,[Identificador]";
                str = str + "      ,F.[Activo],";
                str = str + "(SELECT TOP 1 Valor FROM MRFragancias..Costos C WHERE C.idFragancia = F.idFragancia AND Activo = 1 ORDER BY Fecha DESC) as Costo, ";
                str = str + "(SELECT TOP 1 Fecha FROM MRFragancias..Costos C WHERE C.idFragancia = F.idFragancia AND Activo = 1 ORDER BY Fecha DESC) as FechaActCosto ";
                str = str + "FROM [MRFragancias].[dbo].[Fragancias] F ";
                str = str + "INNER JOIN [MRFragancias].[dbo].[FamiliasOlfativas] FO ON F.idFamiliaOlfativa = FO.idFamiliaOlfativa ";
                str = str + "INNER JOIN [MRFragancias].[dbo].[Estados] E ON F.idEstado = E.idEstado ";
                str = str + "WHERE F.Activo = 1";

                dt = AccesoADatos.connectToDB.fillTableSQL(str);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable obtenerTodos(string columna, string texto)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Fragancias] WHERE " + columna + " LIKE '%" + texto + "%' AND Activo = 1 ");
                return dt;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool agregarObjeto(object _newObject)
        {
            try
            {
                Fragancia _newObj = (Fragancia)_newObject;
                string str = "";
                str = "INSERT INTO [MRFragancias].[dbo].[Fragancias] VALUES (" +
                     "'" + _newObj.NombreReal + "'," +
                     "'" + _newObj.NombreVenta + "'," +
                     "'" + _newObj.idFamiliaOlfativa + "'," +
                     "'" + _newObj.DescOlfativa_NotaSalida + "'," +
                     "'" + _newObj.DescOlfativa_NotaMedia + "'," +
                     "'" + _newObj.DescOlfativa_NotaFondo + "'," +
                     "'" + _newObj.FechaPedidoStock + "'," +
                     "'" + _newObj.idEstado + "'," +
                     "'" + _newObj.FechaIngreso + "'," +
                     "'" + _newObj.ContratipoNombre + "'," +
                     "'" + _newObj.ContratipoMarca + "'," +
                     "'" + _newObj.ContratipoAño + "'," +
                     "'" + _newObj.Equivalencia + "'," +
                     "'" + _newObj.Identificador + "'" +
                     ",1)";

                _newObj.idFragancia = AccesoADatos.connectToDB.launchCommandWithRead(str, "idFragancia");

                str = "INSERT INTO [MRFragancias].[dbo].[Costos] VALUES (" +
                     "'" + _newObj.idFragancia + "'," +
                     "1," +
                     "'" + _newObj.Costo + "'," +
                     "GETDATE()" +
                     ",1)";
                AccesoADatos.connectToDB.launchCommand(str);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool modificarObjeto(object _newObject)
        {
            try
            {
                Fragancia _newObj = (Fragancia)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Fragancias] SET " +
                     "NombreReal = '" + _newObj.NombreReal + "'," +
                     "NombreVenta = '" + _newObj.NombreVenta + "'," +
                     "idFamiliaOlfativa = '" + _newObj.idFamiliaOlfativa + "'," +
                     "DescOlfativa_NotaSalida = '" + _newObj.DescOlfativa_NotaSalida + "'," +
                     "DescOlfativa_NotaMedia = '" + _newObj.DescOlfativa_NotaMedia + "'," +
                     "DescOlfativa_NotaFondo = '" + _newObj.DescOlfativa_NotaFondo + "'," +
                     "FechaPedidoStock = '" + _newObj.FechaPedidoStock + "'," +
                     "idEstado = '" + _newObj.idEstado + "'," +
                     "FechaIngreso = '" + _newObj.FechaIngreso + "'," +
                     "ContratipoNombre = '" + _newObj.ContratipoNombre + "'," +
                     "ContratipoMarca = '" + _newObj.ContratipoMarca + "'," +
                     "ContratipoAño = '" + _newObj.ContratipoAño + "'," +
                     "Equivalencia = '" + _newObj.Equivalencia + "'," +
                     "Identificador = '" + _newObj.Identificador + "'" +
                     " WHERE idFragancia = " + _newObj.idFragancia;
                AccesoADatos.connectToDB.launchCommand(str);


                //Código especial para Costos

                str = "SELECT TOP 1 Valor FROM [MRFragancias].[dbo].[Costos] WHERE idFragancia = " + idFragancia + " AND ACTIVO = 1 ORDER BY Fecha DESC";
                float _costoBD = float.Parse(AccesoADatos.connectToDB.readOneField(str).ToString());

                if (_costoBD != _newObj.Costo) //Verifico si el costo es diferente
                {
                    //Tomo idCosto nuevo
                    str = "SELECT MAX(idCosto) + 1 FROM [MRFragancias].[dbo].[Costos] WHERE idFragancia = " + idFragancia;
                    int idCosto = int.Parse(AccesoADatos.connectToDB.readOneField(str).ToString());


                    //Pongo todos los costos como desactualizados
                    str = "UPDATE [MRFragancias].[dbo].[Costos] SET Activo = 0 WHERE idFragancia = " + idFragancia;
                    AccesoADatos.connectToDB.launchCommand(str);

                    //Inserto el costo
                    str = "INSERT INTO [MRFragancias].[dbo].[Costos] VALUES (" +
                    "'" + _newObj.idFragancia + "'," +
                    idCosto + "," +
                    "'" + _newObj.Costo + "'," +
                    "GETDATE()" +
                    ",1)";
                    AccesoADatos.connectToDB.launchCommand(str);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarObjeto(object _newObject)
        {
            try
            {
                Fragancia _newObj = (Fragancia)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Fragancias] SET Activo = 0 " +
                     " WHERE idFragancia = " + _newObj.idFragancia;
                AccesoADatos.connectToDB.launchCommand(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable obtenerCostos(int idFragancia)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Costos]  WHERE idFragancia = " + idFragancia + " ORDER BY Fecha");
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable obtenerAplicaciones(int idFragancia)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT FA.idFragancia,A.idAplicacion,A.Nombre,FA.AplDetallada FROM [MRFragancias].[dbo].[Fragancias_Aplicaciones] FA INNER JOIN " +
                                        "[MRFragancias].[dbo].[Aplicaciones] A ON a.idAplicacion = FA.idAplicacion " +
                                        "WHERE idFragancia = " + idFragancia);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool agregarAplicacion(int idFragancia, int idAplicacion, string AplDetallada)
        {
            try
            {
                string query = "INSERT INTO [MRFragancias].[dbo].[Fragancias_Aplicaciones] VALUES (" + idFragancia + "," + idAplicacion + ",'" + AplDetallada + "')";
                AccesoADatos.connectToDB.launchCommand(query);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarAplicacion(int idFragancia, int idAplicacion, string AplDetallada)
        {
            try
            {
                AccesoADatos.connectToDB.launchCommand("DELETE FROM [MRFragancias].[dbo].[Fragancias_Aplicaciones] WHERE idFragancia = " + idFragancia + " and idAplicacion = " + idAplicacion + "");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable filtrarFragancias(bool filNombre, bool filCosto, bool filEstado, bool filAplicaciones, bool filFamiliasOlfativas,
                                           bool filNotas, bool filContratipo,
                                           string nombre, float costoMin, float costoMax, DateTime fechaActCosto,
                                           List<string> estados, List<string> aplicaciones, List<string> familias,
                                           string notas, string contratipo)
        {
            try
            {
                DataTable dtResult = new DataTable();

                string str = "SELECT * FROM ";
                str = str + "(";
                str = str + "SELECT *, ";
                str = str + "(SELECT TOP 1 Valor FROM MRFragancias..Costos C WHERE C.idFragancia = F.idFragancia AND Activo = 1 ORDER BY Fecha DESC) as Costo, ";
                str = str + "(SELECT TOP 1 Fecha FROM MRFragancias..Costos C WHERE C.idFragancia = F.idFragancia AND Activo = 1 ORDER BY Fecha DESC) as FechaActCosto ";
                str = str + "FROM [MRFragancias].[dbo].[Fragancias] F WHERE Activo = 1";
                str = str + ") as dbTemp ";
                str = str + "WHERE Activo = 1";

                if (filNombre)
                {
                    str = str + "AND (NombreReal like '%" + nombre + "%' or NombreVenta like '%" + nombre + "%')";
                }

                if (filCosto)
                {
                    str = str + "AND Costo >= " + costoMin + " AND Costo <= " + costoMax + "";
                    str = str + "AND FechaActCosto >= '" + fechaActCosto.ToShortDateString() + "'";
                }

                if (filEstado)
                {
                    string arrayEstados = "";
                    foreach (var item in estados)
                    {
                        arrayEstados = arrayEstados + item + ", ";

                    }
                    arrayEstados = arrayEstados.Trim().Substring(0, arrayEstados.Length - 2);

                    str = str + "AND idEstado in (" + arrayEstados + ")";
                }

                if (filFamiliasOlfativas)
                {
                    string arrayFamilias = "";
                    foreach (var item in familias)
                    {
                        arrayFamilias = arrayFamilias + item + ", ";

                    }
                    arrayFamilias = arrayFamilias.Substring(0, arrayFamilias.Length - 2);

                    str = str + "AND idFamiliaOlfativa in (" + arrayFamilias + ")";
                }

                if (filNotas)
                {
                    str = str + "AND (DescOlfativa_NotaFondo LIKE '%" + notas + "%' OR DescOlfativa_NotaMedia LIKE '%" + notas + "%' OR DescOlfativa_NotaSalida LIKE '%" + notas + "%')";
                }

                if (filContratipo)
                {
                    str = str + "AND (ContratipoAño LIKE '%" + contratipo + "%' OR ContratipoMarca LIKE '%" + contratipo + "' OR ContratipoNombre LIKE '%" + contratipo + "%')";
                }

                if (filAplicaciones)
                {
                    string arrayAplicaciones = "";
                    foreach (var item in aplicaciones)
                    {
                        arrayAplicaciones = arrayAplicaciones + item + ", ";

                    }
                    arrayAplicaciones = arrayAplicaciones.Substring(0, arrayAplicaciones.Length - 2);

                    str = str + "AND idFragancia IN (SELECT DISTINCT idFragancia FROM MRFragancias..Fragancias_Aplicaciones WHERE idAplicacion in (" + arrayAplicaciones + "))";
                }


                dtResult = AccesoADatos.connectToDB.fillTableSQL(str);

                return dtResult;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
