using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleBotCore.Logic
{
    public class SimpleMessage : Base
    {
        public string LogId { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public int Count { set; get; }

        public SimpleMessage(string id, string username, string text)
        {
            this.LogId = id;
            this.User = username;
            this.Text = text;
        }
    }
}