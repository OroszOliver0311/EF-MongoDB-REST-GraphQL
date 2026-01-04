using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mongo.Entitites
{
    [BsonIgnoreExtraElements]
    public class Category
    {
        [BsonId]
        public ObjectId ID { get; set; }
        public string Name { get; set; }

    }
}
