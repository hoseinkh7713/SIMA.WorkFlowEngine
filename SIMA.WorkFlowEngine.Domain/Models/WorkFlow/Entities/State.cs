using SIMA.Framework.Core.Entities;
using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;

public  class State : Entity
{
    protected override string ValidateInvariants()
    {
        throw new NotImplementedException();
    }
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? WorkFlowId { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<Step> Steps { get; set; } = new List<Step>();

    public virtual WorkFlow? WorkFlow { get; set; }

    public virtual ICollection<WorkFlowHistory> WorkFlowHistoryEndPointStates { get; set; } = new List<WorkFlowHistory>();

    public virtual ICollection<WorkFlowHistory> WorkFlowHistoryStats { get; set; } = new List<WorkFlowHistory>();

    
}
