using SIMA.Framework.Core.Entities;
using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;

public class Action : Entity
{
    protected override string ValidateInvariants()
    {
        throw new NotImplementedException();
    }
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int WorkFlow { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual WorkFlow WorkFlowNavigation { get; set; } = null!;
}
