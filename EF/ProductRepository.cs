using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;

namespace ef;

public class ProductRepository
{
    private readonly string _connectionString;
    public ProductRepository(string connectionString)
    {
        this._connectionString = connectionString;
    }

    private ProductDbContext CreateDbContext()
    {
        var contextOptionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
        contextOptionsBuilder.UseSqlServer(_connectionString);
        return new ProductDbContext(contextOptionsBuilder.Options);
    }


    public IReadOnlyCollection<Product> List()
    {
        using var db = CreateDbContext();
        return db.Products.Include(p => p.Vat).Select(p => new Product
        {
            ID = p.ID,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            VatPercentage = p.Vat.Percentage
        })
            .ToList();

        throw new System.NotImplementedException();
    }

    public int Insert(Product value)
    {
        using var db = CreateDbContext();

        var vat = db.Vat.FirstOrDefault(v => v.Percentage == value.VatPercentage);
        
        if (vat == null)
        {
            vat = new DbVat { Percentage = value.VatPercentage, Products = new List<DbProduct>() };
            db.Vat.Add(vat);
            db.SaveChanges(); 
        }

        var product = new DbProduct
        {
            Name = value.Name,
            Price = value.Price,
            Stock = value.Stock,
            VatID = vat.ID
        };

        db.Products.Add(product);
        db.SaveChanges();

        return product.ID;


        throw new System.NotImplementedException();
    }

    public bool Delete(int id)
    {
        using var db = CreateDbContext();

        var product = db.Products.FirstOrDefault(p => p.ID == id);
        if (product == null) return false;

        db.Products.Remove(product);
       
        try
        {
            db.SaveChanges();
            return true;
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }
}
