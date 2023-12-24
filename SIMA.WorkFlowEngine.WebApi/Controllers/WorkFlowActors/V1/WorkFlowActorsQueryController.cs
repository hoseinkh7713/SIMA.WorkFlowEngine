using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor;

namespace SIMA.WorkFlowEngine.WebApi.Controllers.WorkFlowActors.V1
{
    [Route("[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "WorkFlowActors")]
    public class WorkFlowActorsQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkFlowActorsQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<GetWorkFlowActorQueryResult> Get(int id)
        {
            var query = new GetWorkFlowActorQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<GetWorkFlowActorQueryResult>> Get()
        {
            var query = new GetAllWorkFlowActorsQuery();
            return await _mediator.Send(query);
        }
    }
}
