using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Create
{
    public class CreateStateArg
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? WorkFlowId { get; set; }
        public int? ActiveStatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

    }
}
