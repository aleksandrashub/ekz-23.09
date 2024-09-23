﻿using System;
using System.Collections.Generic;

namespace subenok23.Models;

public partial class Manufacturer
{
    public int IdManufacturer { get; set; }

    public string? NameManufacturer { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}