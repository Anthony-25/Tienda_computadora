using Spectre.Console;
using Tienda_computadora.Services;
using Tienda_computadora.Models;

ComputadoraService servicio = new ComputadoraService();

bool salir = false;
while (!salir)
{
    Console.WriteLine();

    AnsiConsole.MarkupLine("[bold yellow]------------------------------------[/]");
    AnsiConsole.MarkupLine (" [green]TIENDA DE COMPUTADORAS[/]");
    AnsiConsole.MarkupLine("[bold yellow]------------------------------------[/]");
    Console.WriteLine();

    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. ver computadoras");
    Console.WriteLine("2. Registrar computadora"); 
    Console.WriteLine("3. Eliminar computadora");
    Console.WriteLine("4. Salir");

    Console.WriteLine("\nSeleccione una opción: ");
    string opcion = Console.ReadLine() ?? string.Empty;

    switch (opcion)
    {
        case "1":
            var lista = servicio.ObtenerComputadoras();
            Table tabla = new Table();
            tabla.Border (TableBorder.Rounded);

            tabla.AddColumn("ID");
            tabla.AddColumn("Nombre");
            tabla.AddColumn("Marca");
            tabla.AddColumn("Procesador");
            tabla.AddColumn("Tipo");
            tabla.AddColumn("Precio");
            tabla.AddColumn("Stock");

            foreach (var computadora in lista)
            {
                tabla.AddRow(
                    computadora.Id.ToString(),
                    computadora.Nombre ?? string.Empty,
                    computadora.Marca ?? string.Empty,
                    computadora.Procesador ?? string.Empty,
                    computadora.Tipo ?? string.Empty,
                    computadora.Precio .ToString("C") ?? string.Empty,
                    computadora.Stock .ToString() ?? string.Empty
                );
            }
             AnsiConsole.Write(tabla);
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("-------- Registrar Computadora --------");
            Computadora nueva = new Computadora();

            Console.Write("ID:");
            nueva.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nombre:");
            nueva.Nombre = Console.ReadLine();
            
            Console.WriteLine("Marca:");
            nueva.Marca = Console.ReadLine();

            Console.WriteLine("Procesador:");
            nueva.Procesador = Console.ReadLine();

            Console.WriteLine("Tipo:");
            nueva.Tipo = Console.ReadLine();

            Console.WriteLine("Precio:");
            nueva.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Stock:");
            nueva.Stock = int.Parse(Console.ReadLine());

            servicio.AgregarComputadora(nueva);
            Console.WriteLine("Computadora registrada exitosamente.");

            break;
        case "3":

            Console.Clear();
            Console.WriteLine("-------- Eliminar Computadora --------");
            Console.WriteLine("Ingrese el ID de la computadora a eliminar:");

            int id = int.Parse(Console.ReadLine());
            bool eliminada = servicio.EliminarComputadora(id);
            if (eliminada)
            {
                Console.WriteLine("Computadora eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró una computadora con ese ID.");
            }
            break;

        case "4":
            salir= true;
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            break;
    }
}

