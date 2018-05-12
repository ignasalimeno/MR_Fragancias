using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuarios
    {
        public string obtenerPassword(string usuario)
        {
            try
            {
                string pass = "";

                pass = AccesoADatos.connectToDB.readOneField("SELECT Password FROM MRFragancias..Usuarios WHERE Usuario = '"+ usuario +"'");

                return pass;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public bool cambiarPassword(string usuario, string password)
        {
            try
            {
                AccesoADatos.connectToDB.launchCommand("UPDATE MRFragancias..Usuarios SET Password = '" + password + "' WHERE Usuario = '" + usuario + "'");
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }

    }
}
