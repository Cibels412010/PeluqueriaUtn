using System;
using System.Collections.Generic;

namespace WebApiTurnos.Models;

public class TTurno
{
    public int Id { get; set; }

    public string? Fecha { get; set; }

    public string? Hora { get; set; }

    public string? Cliente { get; set; }
    //public TDetallesTurno Detalles { get; set; }
}
