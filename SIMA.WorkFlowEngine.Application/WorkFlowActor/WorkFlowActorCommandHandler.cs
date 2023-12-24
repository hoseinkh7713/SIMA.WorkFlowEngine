using AutoMapper;
using MediatR;
using Sima.Framework.Core.Repository;
using SIMA.Framework.Core.Mediator;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlowActor;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Modify;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Interface;
using SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlowActor;

namespace SIMA.WorkFlowEngine.Application.WorkFlowActor
{
    public class WorkFlowActorCommandHandler : ICommandHandler<CreateWorkFlowActorCommand, long>, ICommandHandler<DeleteWorkFlowActorCommand, long>, ICommandHandler<ModifyWorkFlowActorCommand, long>
    {
        private readonly IWorkFlowActorRepository _repository;
        private readonly IWorkFlowActorQueryRepository _queryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkFlowActorCommandHandler(IWorkFlowActorRepository repository, IWorkFlowActorQueryRepository queryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<long> Handle(CreateWorkFlowActorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var arg = _mapper.Map<CreateWorkFlowActorArg>(request);
                var actor = await Domain.Models.WorkFlowActor.Entites.WorkFlowActor.New(arg);
                await _repository.Add(actor);
                await _unitOfWork.SaveChangesAsync();
                request.Id = actor.Id;

                actor.AddActorRole(request.RoleId);
                actor.AddActorGroup(request.GroupId);
                actor.AddActorUser(request.UserId);

                await _unitOfWork.SaveChangesAsync();

                return actor.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<long> Handle(ModifyWorkFlowActorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.FindById(request.Id);
            var arg = _mapper.Map<ModifyWorkFlowActorArg>(request);
            entity.Modify(arg);
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<long> Handle(DeleteWorkFlowActorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.FindById((int)request.Id);
            entity.Deactive();
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }
    }
}
