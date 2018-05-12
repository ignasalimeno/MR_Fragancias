using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Estados
    {
        public int idEstado;
        public string Nombre;
        public bool Activo;

        public DataTable obtenerTodos()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[Estados] WHERE Activo = 1");
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> obtenerIdsPorNombre(List<string> listNombres)
        {
            try
            {
                List<string> _listIds = new List<string>();

                string arrayNombres = "";

                foreach (var item in listNombres)
                {
                    arrayNombres = arrayNombres + "'" + item + "', ";
                }
                arrayNombres = arrayNombres.Substring(0, arrayNombres.Length - 2);

                DataTable dt = AccesoADatos.connectToDB.fillTableSQL("SELECT idEstado FROM [MRFragancias].[dbo].[Estados] WHERE Estado IN (" + arrayNombres + ")");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        _listIds.Add(dt.Rows[i][0].ToString());
                    }
                }
                return _listIds;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
