using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Persona
    {

        string _idcliente;
        string _nombrecompleto;
        string _edad;
        DateTime _fechanacimiento;
        string _direccion;
        string _correo;
        string _celular;
        string _tipomembresia;
        DateTime _fechaInicio;
        DateTime _fechaCorte;
        string _metodoPago;
        string _imagen;
        Single _FingerPrint;
        string _estadoCliente;


        public string IdCliente 
        {
            get { return _idcliente; }
            set { _idcliente = value; }
        }

        public string NombreCompleto 
        {
            get { return _nombrecompleto; }
            set { _nombrecompleto = value; }
        }
        public string Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }
        public DateTime fechaNacimi
        {
            get { return _fechanacimiento; }
            set { _fechanacimiento = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        public string TipoMembresia
        {
            get { return _tipomembresia; }
            set { _tipomembresia = value; }
        }
        public DateTime Fechainicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        public DateTime Fechacorte
        {
            get { return _fechaCorte; }
            set { _fechaCorte = value; }
        }
        public string Metodopago
        {
            get { return _metodoPago; }
            set { _metodoPago = value; }
        }

        public string xImagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        public Single FinfuerPrint
        {
            get { return _FingerPrint; }
            set { _FingerPrint = value; }
        }    

        public string Estadocliente
        {
            get { return _estadoCliente; }
            set { _estadoCliente = value; }
        }

 
    }
}
