using System;
using System.Collections.Generic;

namespace InventoryOrderingSystem.Models.Database;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Stocks { get; set; }

    public decimal Price { get; set; }

    public string? Unit { get; set; }
    public int Id { get; internal set; }
}
