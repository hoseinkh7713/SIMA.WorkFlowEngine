using SIMA.Framework.Core.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;

public partial class WorkFlowActorUser : Entity
{
    private WorkFlowActorUser()
    {

    }
    private WorkFlowActorUser(CreateWorkFlowActorUserArg arg)
    {
        WorkFlowActorId = arg.WorkFlowActorId;
        CreatedAt = DateTime.UtcNow;
        UserId = arg.UserId;
    }
    public static WorkFlowActorUser New(CreateWorkFlowActorUserArg arg)
    {
        return new WorkFlowActorUser(arg);
    }
    protected override string ValidateInvariants()
    {
        throw new NotImplementedException();
    }
    public int Id { get; set; }

    public int WorkFlowActorId { get; set; }

    public int UserId { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual WorkFlowActor WorkFlowActor { get; set; } = null!;

    public virtual ICollection<WorkFlowActorGroup> WorkFlowActorGroups { get; set; } = new List<WorkFlowActorGroup>();

    public virtual ICollection<WorkFlowHistory> WorkFlowHistories { get; set; } = new List<WorkFlowHistory>();
}
