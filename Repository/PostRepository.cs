using Contracts;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        protected PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
