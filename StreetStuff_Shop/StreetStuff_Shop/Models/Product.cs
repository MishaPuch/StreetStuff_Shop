using System;
using System.Collections.Generic;

namespace StreetStuff_Shop.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public int? SexId { get; set; }

    public int? SizeId { get; set; }

    public int? ColorId { get; set; }

    public string? Brand { get; set; }

    public decimal? Price { get; set; }

    public string? Photo { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Color? Color { get; set; }

    public virtual Sex? Sex { get; set; }

    public virtual Size? Size { get; set; }
}
