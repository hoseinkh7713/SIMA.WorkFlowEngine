using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Modify
{
    public class ModifyWorkFlowArg
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int ProjectId { get; set; }
        public long? ManagerRoleId { get; set; }
        public string? Description { get; set; }
        public byte[]? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }

    }
}
