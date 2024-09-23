using System;
using System.Collections.Generic;

namespace subenok23.Models;

public partial class Visit
{
    public int IdVisit { get; set; }

    public int? IdRole { get; set; }

    public int? IdUser { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
