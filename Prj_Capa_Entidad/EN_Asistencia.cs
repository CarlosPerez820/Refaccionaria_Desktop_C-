using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
   public class EN_Asistencia
    {

        string _idAsistencia;
        string _IdCliente;
        DateTime _Fecha;
        string _nombreDia;
        string _horaIngreso;
        DateTime _fechaCorte;
        string _estado;

        public string IdAsistencia { get => _idAsistencia; set => _idAsistencia = value; }
        public string IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public DateTime FechaAsi { get => _Fecha; set => _Fecha = value; }
        public string NombreDia { get => _nombreDia; set => _nombreDia = value; }
        public string HoraIngre { get => _horaIngreso; set => _horaIngreso = value; }
        public DateTime FechaCorte { get => _fechaCorte; set => _fechaCorte = value; }
        public string Estado { get => _estado; set => _estado = value; }
       
    }
}
