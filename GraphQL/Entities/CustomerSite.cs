using System;
using System.Collections.Generic;

namespace graphql.server.Entities;

public partial class CustomerSite
{
    public int Id { get; set; }

    public string ZipCode { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string Tel { get; set; }

    public string Fax { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
