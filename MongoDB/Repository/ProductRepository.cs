using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using mongo.Entitites;
using MongoDB.Bson;
using MongoDB.Driver;

namespace mongo
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> productCollection;
        private readonly IMongoCollection<Category> categoryCollection;
        // Keep the constructor and the field as-is
        public ProductRepository(IMongoDatabase database)
        {
            this.productCollection = database.GetCollection<Product>("products");
            this.categoryCollection = database.GetCollection<Category>("categories");
        }

        public (string, double?) ProductWithLargestTotalValue(ObjectId categoryId)
        {
            var Largest = productCollection
                .Aggregate()
                .Match(c => c.CategoryID == categoryId)
                .Project(p => new
                {
                    p.Name,
                    TotalValue = p.Price * p.Stock
                })
                .SortByDescending(p => p.TotalValue)
                .FirstOrDefault();
       
        return (Largest?.Name, Largest?.TotalValue);

        }

        public double GetAllProductsCumulativeVolume()
        {
            throw new NotImplementedException();
        }

        public Product InsertProduct(string name, string category, int vat)
        {
            var existProduct = productCollection
                .Find(Builders<Product>.Filter.Eq("Name", name))
                .FirstOrDefault();
           
            if (existProduct != null) throw new ArgumentException("Product already exist");
          
            var existCategory = categoryCollection
                .Find(Builders<Category>.Filter.Eq("Name", category))
                .FirstOrDefault();

            if (existCategory == null) throw new ArgumentException("Category does not exist");

            string vatName = "VAT"; 
           
            var existingVAT = productCollection
                .Find(Builders<Product>.Filter.Eq("VAT.Percentage", vat))
                .FirstOrDefault();
            
            if(existingVAT != null) vatName = existingVAT.VAT.Name;

            
            var newProduct = new Product
            {
                ID = ObjectId.GenerateNewId(),
                Name = name,
                CategoryID = existCategory.ID,
                VAT = new VAT
                {
                    Name = vatName,
                    Percentage = vat
                }
            };

            productCollection.InsertOne(newProduct);
           
            return newProduct;


        }
    }
}
