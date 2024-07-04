using MongoDb.Core.Configuaration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MongoDb.Core.Repository
{
    internal class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IBaseDocument
    {
        private readonly IMongoDatabase _mongoDatabase;
        private IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSetting mongoSetting)
        {
            var mongoClient = new MongoClient(mongoSetting.ConnectionStrings);
            _mongoDatabase = mongoClient.GetDatabase(mongoSetting.DbName);
        }

        public void SetCollectionName(string collectionName)
        {
            _collection = _mongoDatabase.GetCollection<TDocument>(collectionName);
        }

        public virtual IQueryable<TDocument> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public virtual IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression,
            int page, int pageSize)
        {
            return _collection.Find(filterExpression)
                .Skip(page * pageSize)
                .Limit(pageSize)
                .ToEnumerable();
        }

        public virtual Task<List<TDocument>> FilterByAsync(Expression<Func<TDocument, bool>> filterExpression,
            int page, int pageSize)
        {
            return _collection.Find(filterExpression)
                .Skip(page * pageSize)
                .Limit(pageSize)
                .ToListAsync();
        }

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression,
            int page, int pageSize)
        {
            return _collection.Find(filterExpression)
                .Project(projectionExpression)
                .Skip(page * pageSize)
                .Limit(pageSize)
                .ToEnumerable();
        }

        public virtual Task<List<TProjected>> FilterByAsync<TProjected>(Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression,
            int page, int pageSize)
        {
            return _collection.Find(filterExpression)
                .Project(projectionExpression)
                .Skip(page * pageSize)
                .Limit(pageSize)
                .ToListAsync();
        }

        public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        public virtual async Task<TDocument> FindById(BsonValue id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", id);
            return (await _collection.FindAsync(filter)).SingleOrDefault();
        }

        public virtual Task<TDocument> FindByIdAsync(BsonValue id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", id);
            return _collection.Find(filter).SingleOrDefaultAsync();
        }


        public virtual void InsertOne(TDocument document)
        {
            _collection.InsertOne(document);
        }

        public virtual Task InsertOneAsync(TDocument document)
        {
            return _collection.InsertOneAsync(document);
        }

        public void InsertMany(ICollection<TDocument> documents)
        {
            _collection.InsertMany(documents);
        }


        public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public void ReplaceOne(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            _collection.FindOneAndReplace(filter, document);
        }

        public virtual async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.FindOneAndDelete(filterExpression);
        }

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.FindOneAndDeleteAsync(filterExpression);
        }

        public void DeleteById(BsonValue id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", id);
            _collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(BsonValue id)
        {
            return Task.Run(() =>
            {
                var filter = Builders<TDocument>.Filter.Eq("_id", id);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
        }
    }
}
