using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Repository
{
    public abstract class BaseRepository<T> where T : Base
    {
        private readonly IMongoDatabase _database = null;
        private IMongoCollection<T> collection;
        protected string CollectionName;

        public BaseRepository(string collectionName, Context ctx)
        {
            _database = ctx.GetClient();
            collection = _database.GetCollection<T>(collectionName);
            CollectionName = collectionName;
        }

        public IMongoCollection<T> Collecction
        {
            get
            {
                return _database.GetCollection<T>(CollectionName);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq("_id", ObjectId.Parse(id));

            T doc = collection.Find(filter).FirstOrDefault();
            return doc;
        }

        public virtual async Task<IEnumerable<T>> Find(string campo, string valor)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq(campo, valor);

            return await collection.Find(filter).ToListAsync();
        }

        public void Add(T entity)
        {
            collection.InsertOne(entity);
        }

        public void Update(T entity)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq("_id", ObjectId.Parse(entity.Id.ToString()));
            var result = collection.ReplaceOne(filter, entity);
        }
    }
}
