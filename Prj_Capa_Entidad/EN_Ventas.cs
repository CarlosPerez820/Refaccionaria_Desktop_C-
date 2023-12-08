using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
  public   class EN_Ventas
    {
        string _FolioVenta;
        DateTime _FechaVenta;
        string _HoraVenta;
        string _FormaPago;
        string _Cliente;
        int _idProducto;
        string _CodigoProducto;
        string _DescripcionProducto;
        string _TipoProducto;
        string _Nota;
        int _CantidadProducto;
        double _PrecioVenta;
        double _PrecioFinal;
        double _ImporteProducto;
        double _SubTotal;
        double _PorcentajeDescuento;
        double _TotalVenta;
        string _Estatus;
    

        public string FolioVenta { get => _FolioVenta; set => _FolioVenta = value; }
        public DateTime FechaVenta { get => _FechaVenta; set => _FechaVenta = value; }
        public string HoraVenta { get => _HoraVenta; set => _HoraVenta = value; }
        public string FormaPago { get => _FormaPago; set => _FormaPago = value; }
        public string Cliente { get => _Cliente; set => _Cliente = value; }
        public int idProducto { get => _idProducto; set => _idProducto = value; }
        public string CodigoProducto { get => _CodigoProducto; set => _CodigoProducto = value; }
        public string DescripcionProducto { get => _DescripcionProducto; set => _DescripcionProducto = value; }
        public string TipoProducto { get => _TipoProducto; set => _TipoProducto = value; }
        public string Nota { get => _Nota; set => _Nota = value; }
        public int CantidadProducto { get => _CantidadProducto; set => _CantidadProducto = value; }
        public double PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }
        public double PrecioFinal { get => _PrecioFinal; set => _PrecioFinal = value; }
        public double ImporteProducto { get => _ImporteProducto; set => _ImporteProducto = value; }
        public double SubTotal { get => _SubTotal; set => _SubTotal = value; }
        public double PorcentajeDescuento { get => _PorcentajeDescuento; set => _PorcentajeDescuento = value; }
        public double TotalVenta { get => _TotalVenta; set => _TotalVenta = value; }
        public string Estatus { get => _Estatus; set => _Estatus = value; }

    }
}
