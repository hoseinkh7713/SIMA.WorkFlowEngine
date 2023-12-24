using SIMA.Framework.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Interface
{
    public interface IWorkFlowRepository : IRepository<Entities.WorkFlow>
    {
        Task<Entities.WorkFlow> GetById(int id);
    }
}
