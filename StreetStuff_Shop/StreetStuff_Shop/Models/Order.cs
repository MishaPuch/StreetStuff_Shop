using System;
using System.Collections.Generic;

namespace StreetStuff_Shop.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public string? Status { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? ProductId { get; set; }

    public virtual User? User { get; set; }
}
