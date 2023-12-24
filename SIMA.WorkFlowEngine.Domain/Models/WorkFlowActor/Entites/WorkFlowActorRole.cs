using SIMA.Framework.Core.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;

public partial class WorkFlowActorRole : Entity
{
    private WorkFlowActorRole()
    {

    }

    private WorkFlowActorRole(CreateWorkFlowActorRoleArg arg)
    {
        WorkFlowActorId = arg.WorkFlowActorId;
        CreatedAt = DateTime.UtcNow;
        RoleId = arg.RoleId;
    }
    public static WorkFlowActorRole New(CreateWorkFlowActorRoleArg arg)
    {
        return new WorkFlowActorRole(arg);
    }
    protected override string ValidateInvariants()
    {
        throw new NotImplementedException();
    }
    public int Id { get; set; }

    public int WorkFlowActorId { get; set; }

    public long RoleId { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual WorkFlowActor WorkFlowActor { get; set; } = null!;
}
