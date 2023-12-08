using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using System.Data;



namespace Prj_Capa_Negocio
{
     public class RN_Personal
    {
        public void RN_Registrar_Personal(EN_Persona per) 
        {
            BD_Personal obj = new BD_Personal();
            obj.BD_Registrar_Personal(per);
        }

        public void RN_actualizar_Personal(EN_Persona per) 
        {
            BD_Personal obj = new BD_Personal();
            obj.BD_actualizar_Personal(per);
        }

        public DataTable RN_Lista_Todo_personal() 
        {
            BD_Personal obj = new BD_Personal();
            return obj.BD_Lista_Todo_personal();
        }

        public DataTable RN_Buscar_personal_porValor(string valor)
        {
            BD_Personal obj = new BD_Personal();
            return obj.BD_Buscar_personal_porValor(valor);
        }

        public void RN_Registrar_Huella_Personal(string idper, object huella)
        {
            BD_Personal obj = new BD_Personal();
            obj.BD_Registrar_Huella_Personal(idper,huella);
        }

        public void RN_Eliminar_Personal(string idper)
        {
            BD_Personal obj = new BD_Personal();
            obj.BD_Eliminar_Personal(idper);
        }


    }
}
