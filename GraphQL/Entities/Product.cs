using System;
using System.Collections.Generic;

namespace graphql.server.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public double? Price { get; set; }

    public int? Stock { get; set; }

    public int? Vatid { get; set; }

    public int? CategoryId { get; set; }

    public string Description { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Vat Vat { get; set; }
}
