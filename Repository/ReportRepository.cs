using Contracts;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        protected ReportRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
