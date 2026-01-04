using System;
using System.Collections.Generic;

namespace graphql.server.Entities;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Method { get; set; }

    public int? Deadline { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
