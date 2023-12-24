using MediatR;
using Microsoft.AspNetCore.Mvc;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlow;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor;

namespace SIMA.WorkFlowEngine.WebApi.Controllers.WorkFlows.V1
{
    [Route("[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "WorkFlows")]
    public class WorkFlowsQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkFlowsQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<GetWorkFlowQueryResult> Get(int id)
        {
            var query = new GetWorkFlowQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<GetWorkFlowQueryResult>> Get()
        {
            var query = new GetAllWorkFlowsQuery();
            return await _mediator.Send(query);
        }
    }
}
