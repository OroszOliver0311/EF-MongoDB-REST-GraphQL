using System;
using System.Collections.Generic;

namespace graphql.server.Entities;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? Deadline { get; set; }

    public int? CustomerSiteId { get; set; }

    public int? StatusId { get; set; }

    public int? PaymentMethodId { get; set; }

    public virtual CustomerSite CustomerSite { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual PaymentMethod PaymentMethod { get; set; }

    public virtual Status Status { get; set; }
}
