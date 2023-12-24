using SIMA.Framework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Create
{
    public class CreateActionArg
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int WorkFlow { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
    }
}
