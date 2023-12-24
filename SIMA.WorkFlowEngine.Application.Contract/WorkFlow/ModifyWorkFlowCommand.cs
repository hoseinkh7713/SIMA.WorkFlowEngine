using Sima.Framework.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Contract.WorkFlow
{
    public class ModifyWorkFlowCommand : ICommand<long>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int ProjectId { get; set; }
        public long? ManagerRoleId { get; set; }
        public string? Description { get; set; }
    }
}
