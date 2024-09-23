using System;
using System.Collections.Generic;

namespace subenok23.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
