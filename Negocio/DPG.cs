using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class DPG
    {
        public double obtenerCosto()
        {
            try
            {
                double costoDPG= 0;

                costoDPG = double.Parse(AccesoADatos.connectToDB.readOneField("SELECT Costo FROM [MRFragancias].[dbo].[DPG] WHERE Activo = 1").ToString());

                return costoDPG;
            }
            catch (Exception)
            {
                
                return 0;
            }
        }
    }
}
