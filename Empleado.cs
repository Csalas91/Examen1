using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Examen
{
    internal class Empleado
    {
        // Atributos y Constructores de la clase Empleado
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public double Salario { get; set; }

        public Empleado(string cedula, string nombre, string direccion, string telefono, double salario)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Salario = salario;
        }
    }
}
