using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser();
        User? GetUserById(int userID);
        void CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
