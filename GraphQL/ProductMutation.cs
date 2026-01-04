using graphql.server.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql.server;

public class ProductMutation
{
    public async Task<IQueryable<Product>> IncreaseProductPricesByCategory(AdatvezDbContext context, string categoryName, double priceIncrease)
    {

        var productsToUpdate = await context.Products
            .Include(p => p.Category)
            .Where(p => p.Category.Name == categoryName)
            .ToListAsync();

        foreach (var product in productsToUpdate)
        {
            if (product.Price.HasValue)
            {
                product.Price = product.Price.Value * priceIncrease;
            }
        }

  
        await context.SaveChangesAsync();

   
        return productsToUpdate.AsQueryable();
    }
    public async Task<Order> CreateOrder(
       AdatvezDbContext context,
       List<string> productNames,
       List<int> quantities)
    {
        if (productNames.Count != quantities.Count)
        {
            throw new ArgumentException("");
        }

        var newOrder = new Order
        {
            Date = DateTime.Now,
            OrderItems = new List<OrderItem>()
        };
        for (int i = 0; i < productNames.Count; i++)
        {
            var productName = productNames[i];
            var quantity = quantities[i];

            var product = await context.Products
                .FirstOrDefaultAsync(p => p.Name == productName);

            if (product == null)
            {
                throw new ArgumentException("");
            }
            var orderItem = new OrderItem
            {
                Product = product,
                ProductId = product.Id,
                Amount = quantity,
                Price = product.Price
            };

            newOrder.OrderItems.Add(orderItem);
        }
        context.Orders.Add(newOrder);
        await context.SaveChangesAsync();

        return newOrder;
    }


}