using Entites;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        protected UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
