using System;
using System.Collections.Generic;

namespace subenok23.Models;

public partial class SrokDostavki
{
    public int IdSrokDost { get; set; }

    public string? ValueSrok { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
