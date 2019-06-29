using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBotCore.Logic.Interface
{
    public interface ILogMongo
    {
        void Adicionar(SimpleMessage message);

        List<BsonDocument> Find(string id);
    }
}
