using SimpleBotCore.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Repository
{
    public class MessageRepository : BaseRepository<SimpleMessage>
    {
        private const string COLLECTION_NAME = "log";
        public MessageRepository(Context ctx) : base(COLLECTION_NAME, ctx) { }

        public Task<IEnumerable<SimpleMessage>> FindLogId(string valor)
        {
            return base.Find("LogId", valor);
        }
    }
}
