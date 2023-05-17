﻿using System;
using System.Collections.Generic;

namespace StreetStuff_Shop.Models;

public partial class Size
{
    public int SizeId { get; set; }

    public string? SizeName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
