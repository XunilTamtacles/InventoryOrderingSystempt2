using System;
using System.Collections.Generic;

namespace InventoryOrderingSystem.Models.Database;

public partial class OrderProductItem
{
    public int OrderProductId { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
    public int Id { get; internal set; }
}
