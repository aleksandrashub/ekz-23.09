using System;
using System.Collections.Generic;

namespace subenok23.Models;

public partial class PunktVydahi
{
    public string? NamePunkt { get; set; }

    public int IdPunkt { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
