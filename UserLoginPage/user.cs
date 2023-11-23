using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserInformation
{
    public class UserClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public ObjectId Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}