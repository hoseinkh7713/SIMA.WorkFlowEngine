using Sima.Framework.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Contract.WorkFlowActor
{
    public class ModifyWorkFlowActorCommand : ICommand<long>
    {
        public int Id { get; set; }
        public string? Name { get; private set; }
        public string? Code { get; private set; }
    }
}

