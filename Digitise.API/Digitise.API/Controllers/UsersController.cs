using System.Linq;
using System.Web.Http;
using Digitise.DataModel.Models;
using Digitise.Services;
using System.Net.Http;
using System.Net;
using Digitise.Services.Interfaces;
using Digitise.Services.Services;
using MongoDB.Bson;

namespace Digitise.API.Controllers
{
    public class UsersController : ApiController
    {

        /// <summary>
        /// dataModle will translate back to the model that you are working with
        /// in this case we are working with the User dataModel
        /// The only thing that needs to change on this page is the Service and Model definitions
        /// </summary>

        //COPY THIS SECTION AND REPLICATE ON OTHER CONTROLLERS
        //----------------------------------------------------------------------------------------------------------

        private readonly IUserService _service;
       
        public UsersController()
        {
            _service = new UserService();
        }
        // GET api/user/id  
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var dataModel = _service.Get(ObjectId.Parse(id));
            if (dataModel != null)
                return Request.CreateResponse(HttpStatusCode.OK, dataModel);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found for provided id.");
        }
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var dataModel = _service.GetAll();
            if (dataModel.Any()) return Request.CreateResponse(HttpStatusCode.OK, dataModel);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No users found.");
        }
        [HttpPost]
        public void Create(User dataModel)
        {
            _service.Insert(dataModel);
        }
        [HttpDelete]
        public void Delete(string id)
        {
            _service.Delete(ObjectId.Parse(id));
        }
        [HttpPut]
        public void Update(User dataModel, string id)
        {
             dataModel.UserId = ObjectId.Parse(id);
            _service.Update(dataModel);
        }

        //----------------------------------------------------------------------------------------------------------

        //                      THE SECTION BELLOW WILL NOT FALL UNDER COMMON CRUD OPPERATIONS
        //----------------------------------------------------------------------------------------------------------
        //*********************************YOUR CUSTOM CODE WILL GO HERE********************************************
        //----------------------------------------------------------------------------------------------------------
    }
}
