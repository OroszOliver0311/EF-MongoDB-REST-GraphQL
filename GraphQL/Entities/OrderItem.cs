using System;
using System.Collections.Generic;

namespace graphql.server.Entities;

public partial class OrderItem
{
    public int Id { get; set; }

    public int? Amount { get; set; }

    public double? Price { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }

    public virtual Status Status { get; set; }
}
