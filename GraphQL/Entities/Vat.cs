using System;
using System.Collections.Generic;

namespace graphql.server.Entities;

public partial class Vat
{
    public int Id { get; set; }

    public int? Percentage { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
