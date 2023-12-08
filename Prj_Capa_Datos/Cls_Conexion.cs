using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prj_Capa_Datos
{
   public class Cls_Conexion
    {

        public string Conectar()
        {
            return @"Server=aws.connect.psdb.cloud;Port=3306;Database=puntodeventa;Uid=5e8vpi6isvbqh5nfwyue;Pwd=pscale_pw_wLey0mFxvhngjZJpa9oYC9uQ6XBOd0Dg6F3i8RJIRje;";


        }

        public static string Conectar2()
        {
            return @"Server=aws.connect.psdb.cloud;Port=3306;Database=puntodeventa;Uid=5e8vpi6isvbqh5nfwyue;Pwd=pscale_pw_wLey0mFxvhngjZJpa9oYC9uQ6XBOd0Dg6F3i8RJIRje;";



        }

    }
}
