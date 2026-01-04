using graphql.server.Entities;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class Query
{
    public IQueryable<Product> GetProducts( AdatvezDbContext context)
    {
        return context.Products
            .Include(p => p.Category)
            .Include(p => p.Vat);
    }

    public IQueryable<Product> GetProductsByCategory(AdatvezDbContext context, string categoryName)
    {
        return context.Products
            .Include(p => p.Category)
            .Include(p => p.Vat)
            .Where(p => p.Category.Name == categoryName);
    }
    [UseProjection]
    public IQueryable<Order> GetOrders(AdatvezDbContext context)
    {
        return context.Orders;
    }
}