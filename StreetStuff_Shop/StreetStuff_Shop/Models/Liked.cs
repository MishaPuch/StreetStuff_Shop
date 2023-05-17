using System;
using System.Collections.Generic;

namespace StreetStuff_Shop.Models;

public partial class Liked
{
    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
