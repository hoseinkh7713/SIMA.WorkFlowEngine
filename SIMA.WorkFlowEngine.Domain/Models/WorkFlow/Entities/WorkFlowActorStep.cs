using SIMA.Framework.Core.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Modify;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;

public  class WorkFlowActorStep : Entity
{

    private WorkFlowActorStep()
    {

    }
    private WorkFlowActorStep(CreateWorkFlowActorStepArg arg)
    {
        StepId = arg.StepId;
        WorkFlowActorId = arg.WorkFlowActorId;
        CreatedAt = DateTime.UtcNow;

    }
    public static WorkFlowActorStep New(CreateWorkFlowActorStepArg arg)
    {
        var result = new WorkFlowActorStep(arg);
        return result;
    }

    public void Deactive()
    {
        ActiveStatusId = 1;
    }
    protected override string ValidateInvariants()
    {
        throw new NotImplementedException();
    }
    public int Id { get; set; }

    public int WorkFlowActorId { get; set; }

    public int StepId { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual Step Step { get; set; } = null!;

    public virtual WorkFlowActor.Entites.WorkFlowActor WorkFlowActor { get; set; } = null!;
}
