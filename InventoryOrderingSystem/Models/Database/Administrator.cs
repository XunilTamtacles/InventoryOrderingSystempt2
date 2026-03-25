using System;
using System.Collections.Generic;

namespace InventoryOrderingSystem.Models.Database;

public partial class Administrator
{
    public int AdminId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string? Username { get; internal set; }
    public string Password { get; internal set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateCreated { get; set; }
}
