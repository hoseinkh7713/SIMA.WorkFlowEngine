using AutoMapper;
using Sima.Framework.Core.Repository;
using SIMA.Framework.Core.Mediator;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor;
using SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlowActor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Query.WorkFlowActor
{
    public class WorkFlowActorQueryHandler : IQueryHandler<GetWorkFlowActorQuery, GetWorkFlowActorQueryResult>, IQueryHandler<GetAllWorkFlowActorsQuery, List<GetWorkFlowActorQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IWorkFlowActorQueryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkFlowActorQueryHandler(IMapper mapper, IWorkFlowActorQueryRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetWorkFlowActorQueryResult> Handle(GetWorkFlowActorQuery request, CancellationToken cancellationToken)
        {
            var actor = await _repository.FindById(request.Id);
            var result = _mapper.Map<GetWorkFlowActorQueryResult>(actor);
            return result;
        }

        public async Task<List<GetWorkFlowActorQueryResult>> Handle(GetAllWorkFlowActorsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
