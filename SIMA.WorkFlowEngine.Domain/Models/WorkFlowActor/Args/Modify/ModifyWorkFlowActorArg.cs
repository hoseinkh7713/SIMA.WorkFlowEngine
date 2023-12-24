using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Modify
{
    public class ModifyWorkFlowActorArg
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public byte[]? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
