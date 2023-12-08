using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;




namespace Prj_Capa_Negocio
{
  public class RN_Utilitario
    {
        public static string RN_NroDoc(int idtipo)
        {
            return BD_Utilitario.BD_NroDoc(idtipo);
        }

        public static void RN_ActualizarNro(int idtipo, string numero)
        {
            BD_Utilitario.BD_ActualizarNro(idtipo, numero);
        }

        public static string RN_Leer_Solo_Numero(int idtipo)
        { 
            return BD_Utilitario.BD_Leer_Solo_Numero(idtipo);
        }

    }
}
