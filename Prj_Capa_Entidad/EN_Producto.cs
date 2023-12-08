using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Producto
    {
        string _Codigo;
        string _Descripcion;
        string _Tipo;
        double _PrecioCompra;
        double _PrecioVenta;
        double _PrecioMayoreo;
        double _PrecioEspecial;
        string _Categoria;
        int _CantidadActual;
        int _CantidadMinima;


        public string Codigo { get => _Codigo; set => _Codigo = value; }

        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public double PrecioCompra { get => _PrecioCompra; set => _PrecioCompra = value; }
        public double PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }
        public double PrecioMayoreo { get => _PrecioMayoreo; set => _PrecioMayoreo = value; }
        public double PrecioEspecial { get => _PrecioEspecial; set => _PrecioEspecial = value; }
        public string Categoria { get => _Categoria; set => _Categoria = value; }
        public int CantidadActual { get => _CantidadActual; set => _CantidadActual = value; }
        public int CantidadMinima { get => _CantidadMinima; set => _CantidadMinima = value; }

    }
}
