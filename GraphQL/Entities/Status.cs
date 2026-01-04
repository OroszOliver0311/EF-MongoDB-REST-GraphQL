using System;
using System.Collections.Generic;

namespace graphql.server.Entities;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
