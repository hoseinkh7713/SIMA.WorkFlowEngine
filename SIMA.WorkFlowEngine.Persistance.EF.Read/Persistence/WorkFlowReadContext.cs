using Microsoft.EntityFrameworkCore;
using SIMA.WorkFlowEngine.Persistance.EF.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.Read.Persistence
{
    public class WorkFlowReadContext : WorkFlowContext
    {
        public WorkFlowReadContext(DbContextOptions<WorkFlowContext> options) : base(options)
        {
        }
    }
}
