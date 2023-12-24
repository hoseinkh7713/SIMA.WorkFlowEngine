using Microsoft.EntityFrameworkCore;
using SIMA.Framework.Infrastructure.Data;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Interface;
using SIMA.WorkFlowEngine.Persistance.EF.Persistence;

namespace SIMA.WorkFlowEngine.Persistance.EF.Repositories.WorkFlowRepository
{
    public class WorkFlowRepository : Repository<WorkFlow>, IWorkFlowRepository
    {
        private readonly WorkFlowContext _context;
        public WorkFlowRepository(WorkFlowContext context) : base(context)
        {
            _context = context;
        }
        public async Task<WorkFlow> GetById(int id)
        {
            var workFlow  =  await _context.WorkFlows.Where(x=>x.Id == id).FirstOrDefaultAsync();
            return workFlow;
        }
    }
}
