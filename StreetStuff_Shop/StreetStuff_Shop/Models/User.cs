﻿using System;
using System.Collections.Generic;

namespace StreetStuff_Shop.Models;

public partial class User 
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? ShippingAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Photo { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    
}
