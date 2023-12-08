using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Cliente
    {

        string _IDCliente;
        string _NombreCompleto;
        string _Direccion;
        string _Telefono;
        int _Credito;

        public string IDCliente { get => _IDCliente; set => _IDCliente = value; }
        public string NombreCompleto { get => _NombreCompleto; set => _NombreCompleto = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public int Credito { get => _Credito; set => _Credito = value; }

    }
}
