using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Apartados
    {

        string _FolioVenta;
        DateTime _FechaVenta;
        string _HoraVenta;
        string _FormaPago;
        string _Cliente;
        string _DescripcionVenta;
        double _TotalVenta;
        double _CantidadAbonada;
        DateTime _FechaUltimoPago;
        double _TotalRestante;
        string _Estatus;


        public string FolioVenta { get => _FolioVenta; set => _FolioVenta = value; }
        public DateTime FechaVenta { get => _FechaVenta; set => _FechaVenta = value; }
        public string HoraVenta { get => _HoraVenta; set => _HoraVenta = value; }
        public string FormaPago { get => _FormaPago; set => _FormaPago = value; }
        public string Cliente { get => _Cliente; set => _Cliente = value; }
        public string DescripcionVenta { get => _DescripcionVenta; set => _DescripcionVenta = value; }
        public double TotalVenta { get => _TotalVenta; set => _TotalVenta = value; }
        public double CantidadAbonada { get => _CantidadAbonada; set => _CantidadAbonada = value; }
        public DateTime FechaUltimoPago { get => _FechaUltimoPago; set => _FechaUltimoPago = value; }
        public double TotalRestante { get => _TotalRestante; set => _TotalRestante = value; }
        public string Estatus { get => _Estatus; set => _Estatus = value; }

    }
}
