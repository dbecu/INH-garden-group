using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace GardenGroupModel
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Branch { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public TypeOfUser TypeOfUser { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        [BsonConstructor]
        public User(string firstName, string lastName, string email, TypeOfUser typeOfUser, string phone, string password, string branch)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            TypeOfUser = typeOfUser;
            Phone = phone;
            Password = password;
            Branch = branch;
        }
    }
}
