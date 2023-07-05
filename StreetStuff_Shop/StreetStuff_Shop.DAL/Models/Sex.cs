using System;
using System.Collections.Generic;

namespace StreetStuff_Shop.Models;

public partial class Sex
{
    public int SexId { get; set; }

    public string? SexName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
