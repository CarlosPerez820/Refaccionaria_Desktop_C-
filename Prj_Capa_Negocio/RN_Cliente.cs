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
    public class RN_Cliente
    {
        public void RN_Registrar_Cliente(EN_Cliente cli)
        {
            BD_Clientes obj = new BD_Clientes();
            obj.BD_Registrar_Clientes(cli);
        }

        public DataTable RN_Listar_Cliente()
        {
            BD_Clientes obj = new BD_Clientes();
            return obj.BD_Listar_Cliente();
        }

        public DataTable RN_Buscar_Cliente_porValor(string id)
        {
            BD_Clientes obj = new BD_Clientes();
            return obj.BD_Buscar_Cliente_porValor(id);
        }
        public void RN_actualizar_Cliente(EN_Cliente cli, string _id)
        {
            BD_Clientes obj = new BD_Clientes();
            obj.BD_Editar_Cliente(cli, _id);
        }
        public void RN_Eliminar_Cliente(string idcli)
        {
            BD_Clientes obj = new BD_Clientes();
            obj.BD_Eliminar_Cliente(idcli);
        }
    }
}
