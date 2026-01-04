using mongo.Entitites;
using MongoDB.Bson;

namespace mongo
{
    public interface IProductRepository
    {
        (string, double?) ProductWithLargestTotalValue(ObjectId categoryId);
        double GetAllProductsCumulativeVolume();
        public Product InsertProduct(string name, string category, int vat);
    }
}
