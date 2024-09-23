using System;
using System.Collections.Generic;

namespace subenok23.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? NameUser { get; set; }

    public string? SurnameUser { get; set; }

    public string? Password { get; set; }

    public string? Login { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
