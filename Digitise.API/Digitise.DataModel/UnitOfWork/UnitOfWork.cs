using MongoDB.Driver;
using Digitise.DataModel.Models;
using Digitise.DataModel.Repository;
using System.Configuration;

namespace Digitise.DataModel.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly IMongoDatabase _database;

        public UnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var mongoClient = new MongoClient(connectionString);
            string databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = mongoClient.GetDatabase(databaseName);
        }

        /// <summary>
        /// MongoDb Will have bunch of collections. 
        /// Collections is what we will call Tables altough they don't realy function the same way.
        /// The Collection is made up of a Bson Document - Binary Json
        /// The Collection wil consist of only one Object
        /// example object:
        /// {
        ///     UserId: 1,
        ///     UserName:Test User,
        ///     UserRoles:
        ///     {
        ///                 Role1:active,
        ///                 Role2:active,
        ///                 Role3:active
        ///     },
        ///     ProfilePicture:img
        /// }
        /// We have to specify the Sets of collections 
        /// </summary>

        #region [Users Collection]
        private DigitiseRepository<User> _users;
        public DigitiseRepository<User> Users
        {
            get
            {
                if (_users == null) _users = new DigitiseRepository<User>(_database, "users");
                return _users;
            }
        }
        #endregion

    }
}
