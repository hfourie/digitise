using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Digitise.DataModel.Repository
{
    public class DigitiseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        // constructor to initialise database and table/collection   
        public DigitiseRepository(IMongoDatabase db, string tblName)
        {
            _collection = db.GetCollection<T>(tblName);
        }

        ///<summary>  
        /// Generic Get method to get record on the basis of id  
        ///</summary>  
        ///<param name="id"></param>  
        ///<returns></returns>  
        public T Get(ObjectId id)
        {
           return _collection.Find(new BsonDocument("_id", id)).FirstOrDefault();
        }

        ///<summary>  
        /// Get all records   
        ///</summary>  
        ///<returns></returns>  
        public IQueryable<T> GetAll()
        {
            var list =  _collection.Find(new BsonDocument()).ToList();
            var test = list.AsQueryable();
            return test;
        }

        ///<summary>  
        /// Generic add method to insert enities to collection   
        ///</summary>  
        ///<param name="entity"></param>  
        public void Add(T entity)
        {
            _collection.InsertOne(entity);
        }

        ///<summary>  
        /// Generic delete method to delete record on the basis of id  
        ///</summary>  
        ///<param name="queryExpression"></param>  
        ///<param name="id"></param>  
        public void Delete(Expression<Func<T, ObjectId>> queryExpression, ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq(queryExpression, id);
             _collection.DeleteOne(filter);
        }

        ///<summary>  
        /// Generic update method to delete record on the basis of id  
        ///</summary>  
        ///<param name="queryExpression"></param>  
        ///<param name="id"></param>  
        ///<param name="entity"></param>  
        public void Update(Expression<Func<T, ObjectId>> queryExpression, ObjectId id, T entity)
        {
            var filter = Builders<T>.Filter.Eq(queryExpression, id);
             _collection.ReplaceOneAsync(filter, entity);
        }

    }
}
