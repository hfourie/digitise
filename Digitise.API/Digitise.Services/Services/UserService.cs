using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digitise.DataModel.Models;
using Digitise.DataModel.UnitOfWork;
using Digitise.Services.Interfaces;
using MongoDB.Bson;

namespace Digitise.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfwork;
        public UserService()
        {
            _unitOfwork = new UnitOfWork();
        }
        public User Get(ObjectId id)
        {
            return  _unitOfwork.Users.Get(id);
        }
        public IQueryable<User> GetAll()
        {
            return  _unitOfwork.Users.GetAll();
        }
        public void Delete(ObjectId id)
        {
             _unitOfwork.Users.Delete(u => u.UserId, id);
        }
        public void Insert(User user)
        {
             _unitOfwork.Users.Add(user);
        }
        public void Update(User user)
        {
             _unitOfwork.Users.Update(u => u.UserId, user.UserId, user);
        }
    }
}
