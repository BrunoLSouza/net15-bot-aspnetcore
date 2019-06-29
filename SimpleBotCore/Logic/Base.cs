using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace SimpleBotCore.Logic
{
    public class Base
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
