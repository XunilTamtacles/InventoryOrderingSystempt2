using System;
using System.Collections.Generic;

namespace InventoryOrderingSystem.Models.Database;

public partial class Administrator
{
    public int AdminId { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateCreated { get; set; }
}
