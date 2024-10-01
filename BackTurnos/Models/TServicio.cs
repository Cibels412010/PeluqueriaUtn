using System;
using System.Collections.Generic;

namespace WebApiTurnos.Models;

public class TServicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Costo { get; set; }

    public string EnPromocion { get; set; } = null!;
}
