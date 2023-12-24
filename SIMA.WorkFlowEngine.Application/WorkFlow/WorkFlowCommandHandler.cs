using AutoMapper;
using Sima.Framework.Core.Repository;
using SIMA.Framework.Core.Mediator;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlow;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlow.WorkFlowTask;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Modify;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Interface;
using SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlow;


namespace SIMA.WorkFlowEngine.Application.WorkFlow
{
    public class WorkFlowCommandHandler : ICommandHandler<CreateWorkFlowCommand, long>, ICommandHandler<DeleteWorkFlowCommand, long>, ICommandHandler<ModifyWorkFlowCommand, long> , ICommandHandler<CreateStepCommand , long>
    {
        private readonly IWorkFlowRepository _repository;
        private readonly IWorkFlowQueryRepository _queryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkFlowCommandHandler(IWorkFlowRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateWorkFlowCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var arg = _mapper.Map<CreateWorkFlowArg>(request);
                var entity = await Domain.Models.WorkFlow.Entities.WorkFlow.New(arg);
                await _repository.Add(entity);
                await _unitOfWork.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task<long> Handle(ModifyWorkFlowCommand request, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.FindById(request.Id);
            var arg = _mapper.Map<ModifyWorkFlowArg>(request);
            entity.Modify(arg);
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<long> Handle(DeleteWorkFlowCommand request, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.FindById((int)request.Id);
            entity.Deactive();
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Handle(CreateStepCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var workflow = await _repository.GetById((int)request.WorkFlowId);
                var arg = _mapper.Map<CreateStepArg>(request);
                var  step =await workflow.AddStep(arg);
                await _unitOfWork.SaveChangesAsync();


                step.AddActorStep(request.ActorId , step.Id);
                await _unitOfWork.SaveChangesAsync();


                return step.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
