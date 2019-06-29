using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Logic.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBotCore.Logic
{
    public class LogMongo : ILogMongo
    {       
        public static IMongoClient client { get; set; }
        public static IMongoDatabase db { get; set; }
        public static IMongoCollection<BsonDocument> col { get; set; }

        public LogMongo()
        {
            client = new MongoClient(Config.ConnectionString);            
            db = client.GetDatabase(Config.Banco);
            col = db.GetCollection<BsonDocument>(Config.Collection);
        }
        
        public void Adicionar(SimpleMessage message)
        {
            var doc = new BsonDocument() {
                { "Id", message.Id },
                { "Usuario", message.User },
                { "Mensagem", message.Text }
            };

            col.InsertOne(doc);            
        }

        public List<BsonDocument> Find(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Id", id);
            return col.Find(filter).ToList();
        }        
    }
}

