using System.Linq;
using Digitise.DataModel.Models;
using MongoDB.Bson;

namespace Digitise.Services.Interfaces
{
    public interface IUserService
    {
        void Insert(User user);
        User Get(ObjectId id);
        IQueryable<User> GetAll();
        void Delete(ObjectId id);
        void Update(User user);
    }
}
