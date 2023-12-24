using SIMA.Framework.Core.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;

public partial class WorkFlowActorGroup : Entity
{

    private WorkFlowActorGroup()
    {

    }
    private WorkFlowActorGroup(CreateWorkFlowActorGroupArg arg)
    {
        WorkFlowActorId = arg.WorkFlowActorId;
        CreatedAt = DateTime.UtcNow;
        GroupId = arg.GroupId;
    }
    public static WorkFlowActorGroup New(CreateWorkFlowActorGroupArg arg)
    {
        return new WorkFlowActorGroup(arg);
    }
    protected override string ValidateInvariants()
    {
        throw new NotImplementedException();
    }
    public int Id { get; set; }

    public int WorkFlowActorId { get; set; }

    public long GroupId { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual WorkFlowActorUser WorkFlowActor { get; set; } = null!;
}
