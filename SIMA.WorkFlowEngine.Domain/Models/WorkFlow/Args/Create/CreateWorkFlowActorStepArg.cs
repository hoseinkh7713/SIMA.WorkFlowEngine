using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Create
{
    public class CreateWorkFlowActorStepArg
    {
        public int WorkFlowActorId { get; set; }
        public int StepId { get; set; }
    }
}
