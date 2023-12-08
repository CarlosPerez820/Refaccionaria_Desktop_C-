using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Negocio
{
    public class RN_Gastos
    {
        public void RN_Registrar_Gasto(EN_Gastos gas)
        {
            BD_Gastos obj = new BD_Gastos();
            obj.BD_Registrar_Gasto(gas);
        }
        public DataTable RN_Listar_Gastos()
        {
            BD_Gastos obj = new BD_Gastos();
            return obj.BD_Listar_Gastos();
        }
        public DataTable RN_Listar_Gastos_Mes()
        {
            BD_Gastos obj = new BD_Gastos();
            return obj.BD_Listar_Gastos_Mes();
        }
        public void RN_Actualizar_Gasto(EN_Gastos gas, int id)
        {
            BD_Gastos obj = new BD_Gastos();
            obj.BD_Editar_Gastos(gas, id);
        }

    }
}
