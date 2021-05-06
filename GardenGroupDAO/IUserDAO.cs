
using System.Collections.Generic;
using GardenGroupModel;

namespace GardenGroupDAO
{
    public interface IUserDAO
    {
        void Create(User newUser);
        void Delete(string id);
        List<User> GetAll();
        User FindById(string id);
        User FindOneByEmail(string email);
        void Update(string id, User user);
    }
}
