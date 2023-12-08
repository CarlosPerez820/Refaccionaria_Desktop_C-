using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;




namespace Prj_Capa_Negocio
{
    public class RN_Producto
    {
        public void RN_Registrar_Producto(EN_Producto pro)
        {
            BD_Producto obj = new BD_Producto();
            obj.BD_Registrar_Producto(pro);
        }

        public DataTable RN_Lista_Todo_Producto()
        {
            BD_Producto obj = new BD_Producto();
            return obj.BD_Lista_Todo_Producto();
        }

        public DataTable RN_Lista_Producto_Bajos()
        {
            BD_Producto obj = new BD_Producto();
            return obj.BD_Lista_Producto_Bajos();
        }

        public void RN_Eliminar_Producto(int idpro)
        {
            BD_Producto obj = new BD_Producto();
            obj.BD_Eliminar_Producto(idpro);
        }

        public DataTable RN_Buscar_producto_porValor(string valor)
        {
            BD_Producto obj = new BD_Producto();
            return obj.BD_Buscar_producto_porValor(valor);
        }
        public DataTable RN_Buscar_producto_porValor_Cadena(string valor)
        {
            BD_Producto obj = new BD_Producto();
            return obj.BD_Buscar_producto_porValor_Cadena(valor);
        }

        public void RN_actualizar_Producto(EN_Producto pro, int _id)
        {
            BD_Producto obj = new BD_Producto();
            obj.BD_actualizar_Producto(pro, _id);
        }

        public void RN_actualizar_Cantidad(int _id, int _cantidad)
        {
            BD_Producto obj = new BD_Producto();
            obj.BD_actualizar_Cantidad(_id, _cantidad);
        }

        public void RN_actualizar_CantidadDevolucion(int _id, int _cantidad)
        {
            BD_Producto obj = new BD_Producto();
            obj.BD_actualizar_CantidadDevolucion(_id, _cantidad);
        }

        public DataTable RN_Buscar_cantidad_Producto(string valor)
        {
            BD_Producto obj = new BD_Producto();
            return obj.BD_Buscar_cantidad_Producto(valor);
        }

    }
}
