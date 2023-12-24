using Microsoft.EntityFrameworkCore;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlow;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor;
using SIMA.WorkFlowEngine.Persistance.EF.Persistence;
using SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlowActor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlow
{
    public class WorkFlowQueryRepository : IWorkFlowQueryRepository
    {
        private readonly WorkFlowContext _context;

        public WorkFlowQueryRepository(WorkFlowContext context)
        {
            this._context = context;
        }
        public async Task<Domain.Models.WorkFlow.Entities.WorkFlow> FindById(int id)
        {
            return await _context.WorkFlows.FirstAsync(x => x.Id == id);
        }

        public async Task<List<GetWorkFlowQueryResult>> GetAll()
        {
            return await _context.WorkFlows.AsNoTracking().Select(x => new GetWorkFlowQueryResult
            {
                Code = x.Code,
                Name = x.Name,
            }).ToListAsync();
        }

        
    }
}
