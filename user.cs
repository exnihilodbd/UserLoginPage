using System;

namespace UserInfo
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}