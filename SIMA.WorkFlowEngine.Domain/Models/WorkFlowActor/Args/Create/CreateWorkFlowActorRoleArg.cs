using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create
{
    public class CreateWorkFlowActorRoleArg
    {
        public int WorkFlowActorId { get; set; }
        public long RoleId { get; set; }
    }
}
