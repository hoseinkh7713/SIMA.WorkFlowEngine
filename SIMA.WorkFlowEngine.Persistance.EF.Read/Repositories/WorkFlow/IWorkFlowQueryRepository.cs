using SIMA.Framework.Core.Repository;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlow;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlow
{
    public interface IWorkFlowQueryRepository : IQueryRepository
    {
        Task<Domain.Models.WorkFlow.Entities.WorkFlow> FindById(int id);
        Task<List<GetWorkFlowQueryResult>> GetAll();
    }
}
