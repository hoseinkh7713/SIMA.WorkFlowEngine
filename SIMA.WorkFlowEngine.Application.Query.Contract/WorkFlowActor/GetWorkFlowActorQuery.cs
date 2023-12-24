using SIMA.Framework.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor
{
    public class GetWorkFlowActorQuery : IQuery<GetWorkFlowActorQueryResult>
    {
        public int Id { get; set; }
    }
}
