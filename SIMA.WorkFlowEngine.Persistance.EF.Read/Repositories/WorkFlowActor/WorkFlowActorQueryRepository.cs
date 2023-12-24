using Microsoft.EntityFrameworkCore;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor;
using SIMA.WorkFlowEngine.Persistance.EF.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlowActor
{
    public class WorkFlowActorQueryRepository : IWorkFlowActorQueryRepository
    {
        private readonly WorkFlowContext _context;

        public WorkFlowActorQueryRepository(WorkFlowContext context)
        {
            this._context = context;
        }
        public async Task<Domain.Models.WorkFlowActor.Entites.WorkFlowActor> FindById(int id)
        {
            return await _context.WorkFlowActors.FirstAsync(x => x.Id == id);
        }

        public async Task<List<GetWorkFlowActorQueryResult>> GetAll()
        {
            try
            {
                return await _context.WorkFlowActors.AsNoTracking().Select(x => new GetWorkFlowActorQueryResult
                {
                    Code = x.Code,
                    Name = x.Name,
                }).ToListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
            

        }
    }
}
