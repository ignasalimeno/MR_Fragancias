
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Nombres
    {
public int idNombre; 
public int idCliente; 
public string Tipo; 
public string Nom; 
public string Observaciones; 
public bool Activo; 


        public DataTable obtenerTodos(int idCliente)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Nombres] WHERE Activo = 1 AND idCliente = " + idCliente);
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
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Nombres] WHERE " + columna + " LIKE '%" + texto + "%' AND Activo = 1 ");
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
                Nombres _newObj = (Nombres)_newObject;
                string str = "";
                str = "INSERT INTO [MRFragancias].[dbo].[Nombres] VALUES (" +
                     "'" + _newObj.idCliente + "'," + 
                     "'" + _newObj.Tipo + "'," + 
                     "'" + _newObj.Nom + "'," + 
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
                Nombres _newObj = (Nombres)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Nombres] SET " +
                     "idCliente = '" + _newObj.idCliente + "'," + 
                     "Tipo = '" + _newObj.Tipo + "'," + 
                     "Nombre = '" + _newObj.Nom + "'," + 
                     "Observaciones = '" + _newObj.Observaciones + "'" + 
                     " WHERE idNombre = " + _newObj.idNombre;
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
                Nombres _newObj = (Nombres)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Nombres] SET Activo = 0 " +
                     " WHERE idNombre = " + _newObj.idNombre;
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
