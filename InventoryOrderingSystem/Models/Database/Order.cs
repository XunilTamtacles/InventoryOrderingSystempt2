using System;
using System.Collections.Generic;

namespace InventoryOrderingSystem.Models.Database;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public decimal Amount { get; set; }

    public DateTime DateCreated { get; set; }

    public string Status { get; set; } = null!;
    public object Customer { get; internal set; }
    public object OrderItems { get; internal set; } = null!;
    public int Id { get; internal set; }
}
