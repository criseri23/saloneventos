using System;

class Reserva
{
    private string nombreCliente;
    private int cantidadInvitados;
    private int cantidadHoras;
    private bool incluyeMozos;
    private char dia;
    private int tipoReserva;
    private char tipoMenu;
    private int cantidadAnimaciones;

    public const int PrecioSalonHora = 6000;
    public const int PrecioMozo = 3000;
    public const int PrecioCateringBasico = 5000;
    public const int PrecioCateringPremium = 11000;
    public const int PrecioAnimacion = 18000;

    public Reserva(string nombreCliente, int cantidadInvitados, int cantidadHoras,
                   bool incluyeMozos, char dia, int tipoReserva,
                   char tipoMenu, int cantidadAnimaciones)
    {
        NombreCliente = nombreCliente;
        CantidadInvitados = cantidadInvitados;
        CantidadHoras = cantidadHoras;
        IncluyeMozos = incluyeMozos;
        Dia = dia;
        TipoReserva = tipoReserva;
        TipoMenu = tipoMenu;
        CantidadAnimaciones = cantidadAnimaciones;
    }

    public string NombreCliente
    {
        get { return nombreCliente; }
        set { nombreCliente = value; }
    }

    public int CantidadInvitados
    {
        get { return cantidadInvitados; }
        set { cantidadInvitados = value; }
    }

    public int CantidadHoras
    {
        get { return cantidadHoras; }
        set { cantidadHoras = value; }
    }

    public bool IncluyeMozos
    {
        get { return incluyeMozos; }
        set { incluyeMozos = value; }
    }

    public char Dia
    {
        get { return dia; }
        set { dia = value; }
    }

    public int TipoReserva
    {
        get { return tipoReserva; }
        set { tipoReserva = value; }
    }

    public char TipoMenu
    {
        get { return tipoMenu; }
        set { tipoMenu = value; }
    }

    public int CantidadAnimaciones
    {
        get { return cantidadAnimaciones; }
        set { cantidadAnimaciones = value; }
    }

    public decimal CalcularValor()
    {
        decimal total = CantidadHoras * PrecioSalonHora;

        if (IncluyeMozos)
        {
            int cantidadMozos = (int)Math.Ceiling(CantidadInvitados / 15.0);
            total += cantidadMozos * PrecioMozo;
        }

        if (Dia == 'S')
        {
            total += total * 0.80m;
        }
        else if (Dia == 'D')
        {
            total += total * 0.50m;
        }

        if (TipoReserva == 2 || TipoReserva == 3)
        {
            if (TipoMenu == 'B')
            {
                total += CantidadInvitados * PrecioCateringBasico;
            }
            else if (TipoMenu == 'P')
            {
                total += CantidadInvitados * PrecioCateringPremium;
            }
        }

        if (TipoReserva == 3)
        {
            total += CantidadAnimaciones * PrecioAnimacion;
        }

        return total;
    }

    public string ObtenerResumen()
    {
        return NombreCliente +
               " - Inv: " + CantidadInvitados +
               " - Horas: " + CantidadHoras +
               " - PRECIO $ " + CalcularValor();
    }
}