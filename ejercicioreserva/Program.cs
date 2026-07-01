
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== SISTEMA DE RESERVAS =====");
        Console.WriteLine();

        Console.Write("Tipo de reserva (1: Solo Evento, 2: Con Catering, 3: Full): ");
        int tipoReserva = int.Parse(Console.ReadLine());

        Console.Write("Nombre del cliente: ");
        string nombre = Console.ReadLine();

        Console.Write("Cantidad de invitados: ");
        int invitados = int.Parse(Console.ReadLine());

        Console.Write("Cantidad de horas: ");
        int horas = int.Parse(Console.ReadLine());

        Console.Write("¿Incluye mozos? (S/N): ");
        bool incluyeMozos = Console.ReadLine().ToUpper() == "S";

        Console.Write("Día (V = Viernes, S = Sábado, D = Domingo): ");
        char dia = char.Parse(Console.ReadLine().ToUpper());

        char tipoMenu = 'N';
        int cantidadAnimaciones = 0;

        if (tipoReserva == 2 || tipoReserva == 3)
        {
            Console.Write("Tipo de menú (B = Básico, P = Premium): ");
            tipoMenu = char.Parse(Console.ReadLine().ToUpper());
        }

        if (tipoReserva == 3)
        {
            Console.Write("Cantidad de animaciones: ");
            cantidadAnimaciones = int.Parse(Console.ReadLine());
        }

        Reserva reserva = new Reserva(
            nombre,
            invitados,
            horas,
            incluyeMozos,
            dia,
            tipoReserva,
            tipoMenu,
            cantidadAnimaciones
        );

        Console.WriteLine();
        Console.WriteLine("===== RESUMEN DE LA RESERVA =====");
        Console.WriteLine(reserva.ObtenerResumen());

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para salir...");
        Console.ReadKey();
    }
}
