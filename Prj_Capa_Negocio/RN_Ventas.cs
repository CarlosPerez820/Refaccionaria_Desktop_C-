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
    public class RN_Ventas
    {
        public void RN_registrar_Venta(EN_Ventas ven)
        {
            BD_Ventas obj = new BD_Ventas();
            obj.BD_registrar_Venta(ven);
        }
        public DataTable RN_Buscar_Venta_porFolio(string valor)
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Buscar_Venta_porFolio(valor);
        }

        public void RN_actualizar_Estatus(string folio, string codigo)
        {
            BD_Ventas obj = new BD_Ventas();
            obj.BD_actualizar_Estado(folio, codigo);
        }
        public DataTable RN_Listar_Devoluciones()
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Listar_Devoluciones();
        }
        public DataTable RN_Buscar_Venta_porDia(string valor)
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Buscar_Venta_porDia(valor);
        }
        public DataTable RN_Lista_Ventas_Semana()
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Buscar_TodasVenta_porSemana();
        }
        public DataTable RN_Lista_Ventas_Mes()
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Lista_Ventas_Mes();
        }
        public DataTable RN_Buscar_Venta_Especifica(string valor, string valor2)
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Buscar_Venta_Especifica(valor, valor2);
        }

        public DataTable RN_Buscar_TodasVenta_porSemana()
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Buscar_TodasVenta_porSemana();
        }

        public DataTable RN_Buscar_TodasVenta_porMes()
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Buscar_TodasVenta_porMes();
        }

        public DataTable RN_Buscar_TodasVenta_porFechas(string valor, string valor2)
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Buscar_TodasVenta_porFechas(valor, valor2);
        }

        public void RN_nuevo_Apartado(EN_Apartados apart)
        {
            BD_Ventas obj = new BD_Ventas();
            obj.BD_nuevo_Apartado(apart);
        }

        public DataTable RN_Listar_Apartados()
        {
            BD_Ventas obj = new BD_Ventas();
            return obj.BD_Listar_Apartados();
        }

        public void RN_Actualizar_Apartado(double abono, DateTime fecha, double restante, int id)
        {
            BD_Ventas obj = new BD_Ventas();
            obj.BD_actualizar_Apartado(abono, fecha, restante, id);
        }

    }
}
