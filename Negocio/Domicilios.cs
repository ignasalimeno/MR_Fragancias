
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Domicilio
    {
public int idDomicilio; 
public int idCliente; 
public string Tipo; 
public string Calle; 
public string Numero; 
public string Piso; 
public string Dpto; 
public string CodPostal; 
public string Localidad; 
public string Provincia; 
public string Observaciones; 
public bool Activo; 


        public DataTable obtenerTodos(int idCliente)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Domicilios] WHERE Activo = 1 AND idCliente = " + idCliente);
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
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Domicilios] WHERE " + columna + " LIKE '%" + texto + "%' AND Activo = 1 ");
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
                Domicilio _newObj = (Domicilio)_newObject;
                string str = "";
                str = "INSERT INTO [MRFragancias].[dbo].[Domicilios] VALUES (" +
                     "'" + _newObj.idCliente + "'," + 
                     "'" + _newObj.Tipo + "'," + 
                     "'" + _newObj.Calle + "'," + 
                     "'" + _newObj.Numero + "'," + 
                     "'" + _newObj.Piso + "'," + 
                     "'" + _newObj.Dpto + "'," + 
                     "'" + _newObj.CodPostal + "'," + 
                     "'" + _newObj.Localidad + "'," + 
                     "'" + _newObj.Provincia + "'," + 
                     "'" + _newObj.Observaciones + "'" + 
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
                Domicilio _newObj = (Domicilio)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Domicilios] SET " +
                     "idCliente = '" + _newObj.idCliente + "'," + 
                     "Tipo = '" + _newObj.Tipo + "'," + 
                     "Calle = '" + _newObj.Calle + "'," + 
                     "Numero = '" + _newObj.Numero + "'," + 
                     "Piso = '" + _newObj.Piso + "'," + 
                     "Dpto = '" + _newObj.Dpto + "'," + 
                     "CodPostal = '" + _newObj.CodPostal + "'," + 
                     "Localidad = '" + _newObj.Localidad + "'," + 
                     "Provincia = '" + _newObj.Provincia + "'," + 
                     "Observaciones = '" + _newObj.Observaciones + "'" + 
                     " WHERE idDomicilio = " + _newObj.idDomicilio;
                AccesoADatos.connectToDB.launchCommand(str);
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
                Domicilio _newObj = (Domicilio)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Domicilios] SET Activo = 0 " +
                     " WHERE idDomicilio = " + _newObj.idDomicilio;
                AccesoADatos.connectToDB.launchCommand(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
