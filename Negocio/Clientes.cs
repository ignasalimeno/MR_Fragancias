
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cliente
    {
        public int idCliente;
        public string RazonSocial;
        public DateTime Fecha_Alta;
        public string Actividad;
        public string CUIT;
        public string Email;
        public string EntregaValores;
        public string CondicionesVenta;
        public string Observaciones;
        public string Vendedor;
        public bool Activo;


        public DataTable obtenerTodos()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Clientes] WHERE Activo = 1");
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
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Clientes] WHERE " + columna + " LIKE '%" + texto + "%' AND Activo = 1 ");
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
                Cliente _newObj = (Cliente)_newObject;
                string str = "";
                str = "INSERT INTO [MRFragancias].[dbo].[Clientes] VALUES (" +
                     "'" + _newObj.RazonSocial + "'," +
                     "'" + _newObj.Fecha_Alta + "'," +
                     "'" + _newObj.Actividad + "'," +
                     "'" + _newObj.CUIT + "'," +
                     "'" + _newObj.Email + "'," +
                     "'" + _newObj.EntregaValores + "'," +
                     "'" + _newObj.CondicionesVenta + "'," +
                     "'" + _newObj.Observaciones + "'," +
                     "'" + _newObj.Vendedor + "'" +
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
                Cliente _newObj = (Cliente)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Clientes] SET " +
                     "RazonSocial = '" + _newObj.RazonSocial + "'," +
                     "Fecha_Alta = '" + _newObj.Fecha_Alta + "'," +
                     "Actividad = '" + _newObj.Actividad + "'," +
                     "CUIT = '" + _newObj.CUIT + "'," +
                     "Email = '" + _newObj.Email + "'," +
                     "EntregaValores = '" + _newObj.EntregaValores + "'," +
                     "CondicionesVenta = '" + _newObj.CondicionesVenta + "'," +
                     "Observaciones = '" + _newObj.Observaciones + "'," +
                     "Vendedor = '" + _newObj.Vendedor + "'" +
                     " WHERE idCliente = " + _newObj.idCliente;
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
                Cliente _newObj = (Cliente)_newObject;
                string str = "";
                str = "UPDATE [MRFragancias].[dbo].[Clientes] SET Activo = 0 " +
                     " WHERE idCliente = " + _newObj.idCliente;
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
