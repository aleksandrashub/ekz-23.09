using System;
using System.Collections.Generic;

namespace subenok23.Models;

public partial class StatusZakaz
{
    public int IdStatus { get; set; }

    public string? NameStatus { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
