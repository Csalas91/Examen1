using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Examen
{
    internal class Menu
    {
        private Empleado[] empleados = new Empleado[100]; // Cambiamos la lista por un arreglo, puedes ajustar el tamaño según tus necesidades.

        private int numEmpleados = 0; // Para llevar un registro del número de empleados.

        public void MostrarMenu()
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Generar Reportes");
            Console.WriteLine("7. Salir");
        }

        public void AgregarEmpleado()
        {
            if (numEmpleados < empleados.Length)
            {
                Console.WriteLine("Agregar Empleado:");
                Console.Write("Cédula: ");
                string cedula = Console.ReadLine();
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Dirección: ");
                string direccion = Console.ReadLine();
                Console.Write("Teléfono: ");
                string telefono = Console.ReadLine();
                Console.Write("Salario: "+"colones");
                double salario = Convert.ToDouble(Console.ReadLine());

                Empleado empleado = new Empleado(cedula, nombre, direccion, telefono, salario);
                empleados[numEmpleados] = empleado;
                numEmpleados++;
                Console.WriteLine("Empleado agregado con éxito.");
            }
            else
            {
                Console.WriteLine("No se pueden agregar más empleados. El límite ha sido alcanzado.");
            }
        }

        public void ConsultarEmpleados()
        {
            Console.WriteLine("Lista de Empleados:");
            for (int i = 0; i < numEmpleados; i++)
            {
                Console.WriteLine($"Cédula: {empleados[i].Cedula}, Nombre: {empleados[i].Nombre}, Salario: {empleados[i].Salario:C}");
            }
        }

        public void ModificarEmpleado()
        {
            Console.Write("Ingrese la cédula del empleado a modificar: ");
            string cedula = Console.ReadLine();
            int indiceEmpleado = -1; // Variable para almacenar el índice del empleado a modificar.

            // Buscamos al empleado y guardamos su índice si se encuentra.
            for (int i = 0; i < numEmpleados; i++)
            {
                if (empleados[i].Cedula == cedula)
                {
                    indiceEmpleado = i;
                    break; // Salimos del ciclo una vez que encontramos el empleado.
                }
            }

            if (indiceEmpleado != -1)
            {
                Console.WriteLine("Empleado encontrado. Ingrese los nuevos datos:");

                Console.Write("Nuevo nombre: ");
                empleados[indiceEmpleado].Nombre = Console.ReadLine();

                Console.Write("Nueva dirección: ");
                empleados[indiceEmpleado].Direccion = Console.ReadLine();

                Console.Write("Nuevo teléfono: ");
                empleados[indiceEmpleado].Telefono = Console.ReadLine();

                Console.Write("Nuevo salario: ");
                empleados[indiceEmpleado].Salario = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Empleado modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void BorrarEmpleado()
        {
            Console.Write("Ingrese la cédula del empleado a borrar: ");
            string cedula = Console.ReadLine();
            int indiceEmpleado = -1; // Variable para almacenar el índice del empleado a borrar.

            // Buscamos al empleado y guardamos su índice si se encuentra.
            for (int i = 0; i < numEmpleados; i++)
            {
                if (empleados[i].Cedula == cedula)
                {
                    indiceEmpleado = i;
                    break; // Salimos del ciclo una vez que encontramos el empleado.
                }
            }

            if (indiceEmpleado != -1)
            {
                // Eliminamos al empleado por su índice.
                for (int i = indiceEmpleado; i < numEmpleados - 1; i++)
                {
                    empleados[i] = empleados[i + 1];
                }

                // Decrementamos el contador de empleados.
                numEmpleados--;

                Console.WriteLine("Empleado eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void InicializarArreglos()
        {
            empleados = new Empleado[100]; // Reemplazamos el arreglo existente con uno nuevo y vacío.
            numEmpleados = 0; // Restablecemos el contador de empleados a cero.
            Console.WriteLine("Arreglos de empleados inicializados.");
        }

        public void GenerarReportes()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú de Reportes");
                Console.WriteLine("1. Consultar empleados con número de cédula.");
                Console.WriteLine("2. Listar todos los empleados ordenados por nombre.");
                Console.WriteLine("3. Calcular y mostrar el promedio de los salarios.");
                Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo.");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese la cédula del empleado a consultar: ");
                        string cedulaConsulta = Console.ReadLine();
                        int indiceEmpleadoConsulta = -1;

                        for (int i = 0; i < numEmpleados; i++)
                        {
                            if (empleados[i].Cedula == cedulaConsulta)
                            {
                                indiceEmpleadoConsulta = i;
                                break;
                            }
                        }

                        if (indiceEmpleadoConsulta != -1)
                        {
                            Console.WriteLine($"Cédula: {empleados[indiceEmpleadoConsulta].Cedula}, Nombre: {empleados[indiceEmpleadoConsulta].Nombre}, Salario: {empleados[indiceEmpleadoConsulta].Salario:C}");
                        }
                        else
                        {
                            Console.WriteLine("Empleado no encontrado.");
                        }
                        break;
                    case 2:
                        ListarEmpleadosOrdenadosPorNombre();
                        break;
                    case 3:
                        CalcularPromedioSalarios();
                        break;
                    case 4:
                        CalcularSalarioMasAltoYMasBajo();
                        break;
                    case 5:
                        Console.WriteLine("Volviendo al menú principal.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 5);
        }
        private void ListarEmpleadosOrdenadosPorNombre()
        {
            // Creamos una copia de los empleados y los ordenamos por nombre.
            Empleado[] empleadosOrdenados = new Empleado[numEmpleados];
            Array.Copy(empleados, empleadosOrdenados, numEmpleados);
            Array.Sort(empleadosOrdenados, (empleado1, empleado2) => empleado1.Nombre.CompareTo(empleado2.Nombre));

            Console.WriteLine("Empleados ordenados por nombre:");
            for (int i = 0; i < numEmpleados; i++)
            {
                Console.WriteLine($"Nombre: {empleadosOrdenados[i].Nombre}, Cédula: {empleadosOrdenados[i].Cedula}, Salario: {empleadosOrdenados[i].Salario:C}");
            }
        }
        private void CalcularPromedioSalarios()
        {
            if (numEmpleados > 0)
            {
                double sumaSalarios = 0.0;
                for (int i = 0; i < numEmpleados; i++)
                {
                    sumaSalarios += empleados[i].Salario;
                }

                double promedioSalarios = sumaSalarios / numEmpleados;
                Console.WriteLine($"El promedio de los salarios es: {promedioSalarios:C}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el promedio de salarios.");
            }
        }
        private void CalcularSalarioMasAltoYMasBajo()
        {
            if (numEmpleados > 0)
            {
                double salarioMasAlto = double.MinValue;
                double salarioMasBajo = double.MaxValue;

                for (int i = 0; i < numEmpleados; i++)
                {
                    double salarioActual = empleados[i].Salario;
                    if (salarioActual > salarioMasAlto)
                    {
                        salarioMasAlto = salarioActual;
                    }
                    if (salarioActual < salarioMasBajo)
                    {
                        salarioMasBajo = salarioActual;
                    }
                }

                Console.WriteLine($"Salario más alto: {salarioMasAlto:C}");
                Console.WriteLine($"Salario más bajo: {salarioMasBajo:C}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el salario más alto y el más bajo.");
            }
        }

    }
   

}
