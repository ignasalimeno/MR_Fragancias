using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public abstract class ObjetoMaestro
    {
        DataTable obtenerTodos()
        {
            return null;
        }

        DataTable obtenerTodos(string columna, string texto)
        {
            return null;
        }

        Boolean agregarObjeto(Object _newObject)
        {
            return true;
        }

        Boolean editarObjeto(Object _newObject)
        {
            return true;
        }

        Boolean eliminarObjeto(Object _newObject)
        {
            return true;
        }
    
    }
}
