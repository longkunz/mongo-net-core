using MongoDB.Bson;
using System.Linq.Expressions;

namespace MongoDb.Core.Repository
{
    public interface IMongoRepository<TDocument>
    {
        /// <summary>
        /// Sets the name of the collection.
        /// </summary>
        /// <param name="name">The name.</param>
        void SetCollectionName(string name);

        /// <summary>
        /// Get queryable.
        /// </summary>
        /// <returns></returns>
        IQueryable<TDocument> AsQueryable();

        /// <summary>
        /// Filters the by.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression,
            int page = DatabaseConstants.DefaultPage, int pageSize = DatabaseConstants.DefaultPageSize);

        /// <summary>
        /// Filters the by asynchronous.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        Task<List<TDocument>> FilterByAsync(Expression<Func<TDocument, bool>> filterExpression,
            int page = DatabaseConstants.DefaultPage, int pageSize = DatabaseConstants.DefaultPageSize);

        /// <summary>
        /// Filters the by.
        /// </summary>
        /// <typeparam name="TProjected">The type of the projected.</typeparam>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="projectionExpression">The projection expression.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression,
            int page = DatabaseConstants.DefaultPage, int pageSize = DatabaseConstants.DefaultPageSize);

        /// <summary>
        /// Filters the by asynchronous.
        /// </summary>
        /// <typeparam name="TProjected">The type of the projected.</typeparam>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="projectionExpression">The projection expression.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        Task<List<TProjected>> FilterByAsync<TProjected>(Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression,
            int page = DatabaseConstants.DefaultPage, int pageSize = DatabaseConstants.DefaultPageSize);

        /// <summary>
        /// Finds the one.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns></returns>
        TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Finds the one asynchronous.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns></returns>
        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TDocument> FindById(BsonValue id);

        /// <summary>
        /// Finds the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TDocument> FindByIdAsync(BsonValue id);

        /// <summary>
        /// Inserts the one.
        /// </summary>
        /// <param name="document">The document.</param>
        void InsertOne(TDocument document);

        /// <summary>
        /// Inserts the one asynchronous.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        Task InsertOneAsync(TDocument document);

        /// <summary>
        /// Inserts the many.
        /// </summary>
        /// <param name="documents">The documents.</param>
        void InsertMany(ICollection<TDocument> documents);

        /// <summary>
        /// Inserts the many asynchronous.
        /// </summary>
        /// <param name="documents">The documents.</param>
        /// <returns></returns>
        Task InsertManyAsync(ICollection<TDocument> documents);

        /// <summary>
        /// Replaces the one.
        /// </summary>
        /// <param name="document">The document.</param>
        void ReplaceOne(TDocument document);

        /// <summary>
        /// Replaces the one asynchronous.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        Task ReplaceOneAsync(TDocument document);

        /// <summary>
        /// Deletes the one.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Deletes the one asynchronous.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns></returns>
        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteById(BsonValue id);

        /// <summary>
        /// Deletes the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteByIdAsync(BsonValue id);

        /// <summary>
        /// Deletes the many.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Deletes the many asynchronous.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns></returns>
        Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
    }
}
