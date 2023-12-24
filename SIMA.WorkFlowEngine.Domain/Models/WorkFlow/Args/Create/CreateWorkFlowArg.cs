using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Create
{
    public class CreateWorkFlowArg
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int ProjectId { get; set; }
        public long? ManagerRoleId { get; set; }
        public string? Description { get; set; }
        public int? ActiveStatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

    }
}
