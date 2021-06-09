using EmpleadoApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoApp.Poco
{
    public class Empleado
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Cedula { get; set; }
        public String Telefono { get; set; }
        public String Correo { get; set; }

        public TipoProfesion TipoProfesion { get; set; }
        public TipoCargo TipoCargo { get; set; }

        public double Salario { get; set; }
    }
}
