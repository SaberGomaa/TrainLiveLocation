using Contracts;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        protected AdminRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
