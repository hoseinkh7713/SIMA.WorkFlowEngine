using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create
{
    public class CreateWorkFlowActorUserArg
    {
        public int WorkFlowActorId { get; set; }
        public int UserId { get; set; }
    }
}
