using System;

class Reserva
{

    private const int PRECIO_SALON = 6000;
    private const int PRECIO_MOZO = 3000;
    private const int CATERING_BASICO = 5000;
    private const int CATERING_PREMIUM = 11000;
    private const int PRECIO_ANIMACION = 18000;


    private string nombreCliente;
    private int cantidadInvitados;
    private int cantidadHoras;
    private bool incluyeMozos;
    private char dia;
    private int tipoReserva;
    private char tipoMenu;
    private int cantidadAnimaciones;

    
    public Reserva(string nombreCliente, int cantidadInvitados, int cantidadHoras,
                   bool incluyeMozos, char dia, int tipoReserva,
                   char tipoMenu, int cantidadAnimaciones)
    {
        this.nombreCliente = nombreCliente;
        this.cantidadInvitados = cantidadInvitados;
        this.cantidadHoras = cantidadHoras;
        this.incluyeMozos = incluyeMozos;
        this.dia = dia;
        this.tipoReserva = tipoReserva;
        this.tipoMenu = tipoMenu;
        this.cantidadAnimaciones = cantidadAnimaciones;
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

    public int CalcularValor()
    {
        int total = 0;

        total = cantidadHoras * PRECIO_SALON;

   
        if (incluyeMozos)
        {
            int mozos = cantidadInvitados / 15;

            if (cantidadInvitados % 15 != 0)
            {
                mozos++;
            }

            total += mozos * PRECIO_MOZO;
        }

        // Recargo por día
        if (dia == 'S')
        {
            total += (int)(total * 0.80);
        }
        else if (dia == 'D')
        {
            total += (int)(total * 0.50);
        }

        // Catering
        if (tipoReserva == 2 || tipoReserva == 3)
        {
            if (tipoMenu == 'B')
            {
                total += cantidadInvitados * CATERING_BASICO;
            }
            else if (tipoMenu == 'P')
            {
                total += cantidadInvitados * CATERING_PREMIUM;
            }
        }

        // Animaciones
        if (tipoReserva == 3)
        {
            total += cantidadAnimaciones * PRECIO_ANIMACION;
        }

        return total;
    }

    // Devuelve el resumen
    public string ObtenerResumen()
    {
        return nombreCliente +
               " - Inv: " + cantidadInvitados +
               " - Horas: " + cantidadHoras +
               " - PRECIO $ " + CalcularValor();
    }
}
