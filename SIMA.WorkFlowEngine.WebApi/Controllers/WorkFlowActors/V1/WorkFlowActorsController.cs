using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlowActor;

namespace SIMA.WorkFlowEngine.WebApi.Controllers.WorkFlowActors.V1
{
    [Route("[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "WorkFlowActors")]
    public class WorkFlowActorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkFlowActorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<long> Post([FromBody] CreateWorkFlowActorCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPut]
        public async Task<long> Put([FromBody] ModifyWorkFlowActorCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }


        [HttpDelete("{id}")]
        public async Task<long> Delete(int id)
        {
            var command = new DeleteWorkFlowActorCommand { Id = id };
            return await _mediator.Send(command);
        }
    }
}
