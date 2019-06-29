using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBotCore.Logic
{
    public class Context
    {       
        private IMongoClient client { get; set; }
        private IMongoDatabase db { get; set; }
        private IMongoCollection<BsonDocument> col { get; set; }

        public Context()
        {
            client = new MongoClient(Config.ConnectionString);            
            db = client.GetDatabase(Config.Banco);
        }

        public IMongoDatabase GetClient()
        {
            return db;
        }  
    }
}

