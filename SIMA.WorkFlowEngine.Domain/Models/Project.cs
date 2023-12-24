using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models;

public partial class Project
{
    public int Id { get; set; }

    public int? DomainId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();

    public virtual ICollection<WorkFlow.Entities.WorkFlow> WorkFlows { get; set; } = new List<WorkFlow.Entities.WorkFlow>();
}
