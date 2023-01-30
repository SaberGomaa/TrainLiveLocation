using Contracts;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TeketRepository : RepositoryBase<Ticket>, ITeketRepository
    {
        protected TeketRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
