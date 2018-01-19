using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Digitise.DataModel.Models
{
    public class User
    {
        /// <summary>
        /// Here, [BsonElement("_id")] attribute tells MongoDB that Id is going to be used as unique key i.e. _id in user collection.
        /// </summary>
        
        [BsonId]
        [BsonElement("_id")]
        public ObjectId UserId { get; set; }
        public string Name { get; set; }
    }
}
