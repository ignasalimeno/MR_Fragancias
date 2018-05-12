using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class Nota
    {
        public int idNota;
        public int idCliente;
        public DateTime FechaNota;
        public string Texto;
        public bool Activo;


        public DataTable obtenerTodos(int idCliente)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Notas] WHERE Activo = 1 AND idCliente = " + idCliente);
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
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Notas] WHERE " + columna + " LIKE '%" + texto + "%' AND Activo = 1 ");
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
                Nota _newObj = (Nota)_newObject;
                string str = "";
                str = "INSERT INTO [MRFragancias].[dbo].[Notas] VALUES (" +
                     "'" + _newObj.idCliente + "'," +
                     "'" + _newObj.FechaNota + "'," +
                     "'" + _newObj.Texto + "'" +
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
                Nota _newObj = (Nota)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Notas] SET " +
                     "idCliente = '" + _newObj.idCliente + "'," +
                     "FechaNota = '" + _newObj.FechaNota + "'," +
                     "Texto = '" + _newObj.Texto + "'" +
                     " WHERE idNota = " + _newObj.idNota;
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
                Nota _newObj = (Nota)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Notas] SET Activo = 0 " +
                     " WHERE idNota = " + _newObj.idNota;
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
