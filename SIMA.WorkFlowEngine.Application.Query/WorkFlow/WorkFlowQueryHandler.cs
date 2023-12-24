using AutoMapper;
using Sima.Framework.Core.Repository;
using SIMA.Framework.Core.Mediator;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlow;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor;
using SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlow;
using SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlowActor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Query.WorkFlow
{
    public class WorkFlowQueryHandler : IQueryHandler<GetAllWorkFlowsQuery, List<GetWorkFlowQueryResult>> , IQueryHandler<GetWorkFlowQuery, GetWorkFlowQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IWorkFlowQueryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkFlowQueryHandler(IMapper mapper, IWorkFlowQueryRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetWorkFlowQueryResult> Handle(GetWorkFlowQuery request, CancellationToken cancellationToken)
        {
            var actor = await _repository.FindById(request.Id);
            var result = _mapper.Map<GetWorkFlowQueryResult>(actor);
            return result;
        }

        public async Task<List<GetWorkFlowQueryResult>> Handle(GetAllWorkFlowsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
