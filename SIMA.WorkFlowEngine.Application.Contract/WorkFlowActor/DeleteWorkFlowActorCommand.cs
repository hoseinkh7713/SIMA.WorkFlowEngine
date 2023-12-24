using Sima.Framework.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Contract.WorkFlowActor
{
    public class DeleteWorkFlowActorCommand : ICommand<long>
    {
        public int Id { get; set; }
    }
}
