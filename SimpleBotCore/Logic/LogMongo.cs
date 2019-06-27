using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace SimpleBotCore.Logic
{
    public static class LogMongo
    {
        public static string ConnectionString { get; set; }
        public static string Banco { get; set; }
        public static string Collection { get; set; }
        public static IMongoClient client { get; set; }
        public static IMongoDatabase db { get; set; }
        public static IMongoCollection<BsonDocument> col { get; set; }
        public static void Iniciar()
        {
            client = new MongoClient(ConnectionString);
            db = client.GetDatabase(Banco);
            col = db.GetCollection<BsonDocument>(Collection);
        }

        public static void AdicionaLog(ref SimpleMessage message)
        {   
            message.Count = countLog(message);
        }
        private static int countLog(SimpleMessage message)
        {
            var doc = new BsonDocument() {
                { "Id", message.Id },
                { "Usuario", message.User },
                { "Mensagem", message.Text }
            };

            col.InsertOne(doc);
        
            var filter = Builders<BsonDocument>.Filter.Eq("Id", message.Id);
            var results = col.Find(filter).ToList();
            return results.Count();
        }
    }
}

