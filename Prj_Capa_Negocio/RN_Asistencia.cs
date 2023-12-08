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
    public class RN_Asistencia
    {
        public bool RN_Verificar_si_Personal_YaMarco_su_Asistencia(string idper)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Verificar_si_Cliente_YaMarco_su_Asistencia(idper);
        }

        public bool RN_Verificar_si_Personal_YaMarco_su_Entrada(string idper)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Verificar_si_Cliente_YaMarco_su_Entrada(idper);
        }

        public void RN_registrar_entrada(EN_Asistencia asi)
        {
            BD_Asistencia obj = new BD_Asistencia();
            obj.BD_registrar_entrada(asi);
        }

        public DataTable RN_listar_todas_asistencias() 
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Listar_Todas_Asistencias();
        }

        public DataTable RN_Buscar_Asistencia_porValor(string valor)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Buscar_Asistencia_porValor(valor);
        }

        public DataTable RN_Buscar_Asistencia_porNombre(string valor) 
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Buscar_Asistencia_porNombre(valor);
        }
        public DataTable RN_Listar_numero_Visitas_por_cliente(string valor)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Listar_numero_Visitas_por_cliente(valor);
        }

        public DataTable RN_Listar_Meses_Pagados(string valor)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Meses_Pagados(valor);
        }

        public DataTable RN_Listar_Visitar_x_Mes()
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Listar_Visitar_x_Mes();
        }

        public DataTable RN_Listar_Visitar_x_Semana()
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Listar_Visitar_x_Semana();
        }

        public DataTable RN_Listar_Visitar_x_Dia()
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Listar_Visitar_x_Dia();
        }


    }
}
