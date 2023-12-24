using SIMA.Framework.Core.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Modify;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;
using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;

public class Step : Entity
{
    private Step()
    {

    }
    private Step(CreateStepArg arg)
    {
        Id = arg.Id;
        Name = arg.Name;
        Code = arg.Code;
        MainEntityId = arg.MainEntityId;
        WorkFlowId = arg.WorkFlowId;
        StepNumber = arg.StepNumber;
        RejectStepNumber = arg.RejectStepNumber;
        NextStepNumber = arg.NextStepNumber;
        IsLastStep = arg.IsLastStep;
        AttachmentCountLimitation = arg.AttachmentCountLimitation;
        IsAttachmentRequired = arg.IsAttachmentRequired;
        IsSetReciverRequired = arg.IsSetReciverRequired;
        Description = arg.Description;
        CreatedBy = arg.CreatedBy;
        CreatedAt = arg.CreatedAt;
    }
    public static async Task<Step> New(CreateStepArg arg)
    {
        return new Step(arg);
    }
    public void AddActorStep(List<int> actorId , int stepId)
    {
        var actorStep =  actorId.Select(x => WorkFlowActorStep.New(new CreateWorkFlowActorStepArg { WorkFlowActorId = x, StepId = stepId }));
        _workFlowActorStep.AddRange(actorStep);
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

    public string? Name { get; set; }

    public string? Code { get; set; }

    public long? MainEntityId { get; set; }

    public int? WorkFlowId { get; set; }

    public int? StateId { get; set; }

    public int? StepNumber { get; set; }

    public int? RejectStepNumber { get; set; }

    public int? NextStepNumber { get; set; }

    public string? IsActive { get; set; }

    public string? IsLastStep { get; set; }

    public int? AttachmentCountLimitation { get; set; }

    public string? IsAttachmentRequired { get; set; }

    public string? IsSetReciverRequired { get; set; }

    public string? Description { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<RejectionReason> RejectionReasons { get; set; } = new List<RejectionReason>();

    public virtual State? State { get; set; }

    public virtual WorkFlow? WorkFlow { get; set; }


    private List<WorkFlowActorStep> _workFlowActorStep = new();
    public  ICollection<WorkFlowActorStep> WorkFlowActorSteps => _workFlowActorStep.AsReadOnly();

    public virtual ICollection<WorkFlowHistory> WorkFlowHistoryEndPointSteps { get; set; } = new List<WorkFlowHistory>();

    public virtual ICollection<WorkFlowHistory> WorkFlowHistoryStatNavigations { get; set; } = new List<WorkFlowHistory>();
}
