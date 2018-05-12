
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Contactos
    {
        public int idContacto;
        public int idCliente;
        public string Nombre;
        public string Cargo;
        public string Telefono;
        public string Email;
        public string Observaciones;
        public bool Activo;


        public DataTable obtenerTodos(int idCliente)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Contactos] WHERE Activo = 1 AND idCliente = " + idCliente);
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
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Contactos] WHERE " + columna + " LIKE '%" + texto + "%' AND Activo = 1 ");
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
                Contactos _newObj = (Contactos)_newObject;
                string str = "";
                str = "INSERT INTO [MRFragancias].[dbo].[Contactos] VALUES (" +
                     "'" + _newObj.idCliente + "'," +
                     "'" + _newObj.Nombre + "'," +
                     "'" + _newObj.Cargo + "'," +
                     "'" + _newObj.Telefono + "'," +
                     "'" + _newObj.Email + "'," +
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
                Contactos _newObj = (Contactos)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Contactos] SET " +
                     "idCliente = '" + _newObj.idCliente + "'," +
                     "Nombre = '" + _newObj.Nombre + "'," +
                     "Cargo = '" + _newObj.Cargo + "'," +
                     "Telefono = '" + _newObj.Telefono + "'," +
                     "Email = '" + _newObj.Email + "'," +
                     "Observaciones = '" + _newObj.Observaciones + "'" +
                     " WHERE idContacto = " + _newObj.idContacto;
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
                Contactos _newObj = (Contactos)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Contactos] SET Activo = 0 " +
                     " WHERE idContacto = " + _newObj.idContacto;
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
