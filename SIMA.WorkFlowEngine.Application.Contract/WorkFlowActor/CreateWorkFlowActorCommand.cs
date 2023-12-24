using Sima.Framework.Core.Mediator;

namespace SIMA.WorkFlowEngine.Application.Contract.WorkFlowActor
{
    public class CreateWorkFlowActorCommand : ICommand<long>
    {
        public int Id { get; set; }
        public List<long>? RoleId { get; set; }
        public List<int>? UserId { get; set; }
        public List<int>? GroupId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

    }
}
