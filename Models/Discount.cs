using System;
using System.Collections.Generic;

namespace subenok23.Models;

public partial class Discount
{
    public int IdDiscount { get; set; }

    public int? ValueDiscount { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
