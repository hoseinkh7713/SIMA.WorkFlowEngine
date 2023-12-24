using SIMA.Framework.Infrastructure.Data;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Interface;
using SIMA.WorkFlowEngine.Persistance.EF.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.Repositories.WorkFlowActorRepository
{
    public class WorkFlowActorRepository : Repository<WorkFlowActor>, IWorkFlowActorRepository
    {
        public WorkFlowActorRepository(WorkFlowContext context) : base(context)
        {
        }
    }
}
