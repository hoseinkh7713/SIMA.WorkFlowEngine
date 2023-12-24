using MediatR;
using Microsoft.AspNetCore.Mvc;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlow;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlow.WorkFlowTask;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlowActor;

namespace SIMA.WorkFlowEngine.WebApi.Controllers.WorkFlows.V1
{
    [Route("[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "WorkFlows")]
    public class WorkFlowsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkFlowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<long> Post([FromBody] CreateWorkFlowCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPost("InsertStep")]
        public async Task<long> Post([FromBody] CreateStepCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPut]
        public async Task<long> Put([FromBody] ModifyWorkFlowCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
