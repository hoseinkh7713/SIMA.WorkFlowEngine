using SIMA.Framework.Core.Repository;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlowActor
{
    public interface IWorkFlowActorQueryRepository : IQueryRepository
    {
        Task<Domain.Models.WorkFlowActor.Entites.WorkFlowActor> FindById(int id);
        Task<List<GetWorkFlowActorQueryResult>> GetAll();
    }
}
