using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models;

public partial class ProjectMember
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int UserId { get; set; }

    public string IsManager { get; set; } = null!;

    public string IsAdminProject { get; set; } = null!;

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual Project Project { get; set; } = null!;
}
