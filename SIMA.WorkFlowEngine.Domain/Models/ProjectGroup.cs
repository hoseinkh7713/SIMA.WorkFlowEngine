using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models;

public partial class ProjectGroup
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int GroupId { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }
}
