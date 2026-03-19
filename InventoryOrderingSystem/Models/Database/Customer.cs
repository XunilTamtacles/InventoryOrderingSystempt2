using System;
using System.Collections.Generic;

namespace InventoryOrderingSystem.Models.Database;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool IsActive { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    public int Id { get; internal set; }
    public string Name { get; internal set; }
}
