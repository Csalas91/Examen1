using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Examen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            int opcion;
            do // PARA PROCESAR LAS OPCIONES Y PODER SALIR DEL SISTEMA
            {
                menu.MostrarMenu();
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        menu.AgregarEmpleado();
                        break;
                    case 2:
                        menu.ConsultarEmpleados();
                        break;
                    case 3:
                        menu.ModificarEmpleado();
                        break;
                    case 4:
                        menu.BorrarEmpleado();
                        break;
                    case 5:
                        menu.InicializarArreglos();
                        break;
                    case 6:
                        menu.GenerarReportes();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo del sistema.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 7);
        }
    }
}
