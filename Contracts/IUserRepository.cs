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
        User? CheckEmail(string Email);
        User? CheckPhone(string Phone);
        void CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
