
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Telefono
    {
public int idTelefono; 
public int idCliente; 
public string Tipo; 
public string Numero; 
public string Interno; 
public string Observaciones; 
public bool Activo; 


        public DataTable obtenerTodos(int idCliente)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Telefonos] WHERE Activo = 1 AND idCliente = " + idCliente);
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
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Telefonos] WHERE " + columna + " LIKE '%" + texto + "%' AND Activo = 1 ");
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
                Telefono _newObj = (Telefono)_newObject;
                string str = "";
                str = "INSERT INTO [MRFragancias].[dbo].[Telefonos] VALUES (" +
                     "'" + _newObj.idCliente + "'," + 
                     "'" + _newObj.Tipo + "'," + 
                     "'" + _newObj.Numero + "'," + 
                     "'" + _newObj.Interno + "'," + 
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
                Telefono _newObj = (Telefono)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Telefonos] SET " +
                     "idCliente = '" + _newObj.idCliente + "'," + 
                     "Tipo = '" + _newObj.Tipo + "'," + 
                     "Numero = '" + _newObj.Numero + "'," + 
                     "Interno = '" + _newObj.Interno + "'," + 
                     "Observaciones = '" + _newObj.Observaciones + "'" + 
                     " WHERE idTelefono = " + _newObj.idTelefono;
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
                Telefono _newObj = (Telefono)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Telefonos] SET Activo = 0 " +
                     " WHERE idTelefono = " + _newObj.idTelefono;
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
