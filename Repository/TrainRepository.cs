using Contracts;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TrainRepository : RepositoryBase<Train>, ITrainRepository
    {
        public TrainRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

    }
}
