using SIMA.Framework.Core.Entities;
using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;

public class RejectionReason : Entity
{
    protected override string ValidateInvariants()
    {
        throw new NotImplementedException();
    }

    public int Id { get; set; }

    public int StepId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual Step Step { get; set; } = null!;

    public virtual ICollection<WorkFlowHistory> WorkFlowHistories { get; set; } = new List<WorkFlowHistory>();

    
}
