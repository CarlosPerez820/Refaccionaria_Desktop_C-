using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Gastos
    {
        DateTime _fecha;
        string _descripcion;
        double _monto;

        public DateTime fecha { get => _fecha; set => _fecha = value; }
        public string descripcion { get => _descripcion; set => _descripcion = value; }
        public double monto { get => _monto; set => _monto = value; }
    }
}
