using System.Collections.Generic;
using webapi.Model;

namespace webapi.DAL
{
  
    public interface IProductRepository
    {
        Product GetById(int id);
        IReadOnlyCollection<Product> List();
        void Add(Product product);
        void Update(int id, Product product);
        bool Delete(int id);
    }
}