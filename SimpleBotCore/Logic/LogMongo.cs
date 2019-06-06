using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SimpleBotCore.Logic
{
    public class LogMongo
    {

        public void AdicionaLog(ref SimpleMessage msg)
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var db = client.GetDatabase("BotDB");
            var col = db.GetCollection<BsonDocument>("log");


            //grava log
            var log = new BsonDocument()
            {
                {"Id",msg.Id },
                {"Usuario",msg.User },
                {"Mensagem", msg.Text }
            };
            col.InsertOne(log);

            //find para count
            //var filtro = new BsonDocument() {};
            var filtro = new BsonDocument() {
                {"Id", msg.Id.ToString()}
            };

            //string sFiltro = "{num: {$gt: 5}}";
            //var filtro = BsonDocument.Parse(sFiltro);
            //Builders<BsonDocument>.Filter.Gt();

            var res = col.Find(filtro).ToList();

            msg.Count = res.Count();
        }

    }
}
