using System;
using System.Collections.Generic;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;

namespace SIMA.WorkFlowEngine.Domain.Models;

public partial class WorkFlowHistory
{
    public long Id { get; set; }

    public int StatId { get; set; }

    public int StepId { get; set; }

    public int DomainId { get; set; }

    public long MainEntityId { get; set; }

    public int MainEntityRecordId { get; set; }

    public string? Description { get; set; }

    public int RejectionReasonId { get; set; }

    public int StartPointUserId { get; set; }

    public int EndPointUserId { get; set; }

    public int EndPointStepId { get; set; }

    public int EndPointStateId { get; set; }

    public int EndWorkFlowActorId { get; set; }

    public int? StepNumber { get; set; }

    public int? RejectionStepNumber { get; set; }

    public int? NextStepNumber { get; set; }

    public string IsLastStep { get; set; } = null!;

    public int? AttachmentCountLimitation { get; set; }

    public string? IsAttachmentRequired { get; set; }

    public string? IsSetReceiverRequired { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public int? ActiveStatusId { get; set; }

    public virtual State EndPointState { get; set; } = null!;

    public virtual Step EndPointStep { get; set; } = null!;

    public virtual WorkFlowActorUser EndWorkFlowActor { get; set; } = null!;

    public virtual RejectionReason RejectionReason { get; set; } = null!;

    public virtual State Stat { get; set; } = null!;

    public virtual Step StatNavigation { get; set; } = null!;
}
