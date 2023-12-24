using SIMA.Framework.Core.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Modify;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Modify;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;
using System;
using System.Collections.Generic;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;

public class WorkFlow : Entity
{
    private WorkFlow()
    {

    }
    private WorkFlow(CreateWorkFlowArg arg)
    {
        Id = arg.Id;
        Name = arg.Name;
        Code = arg.Code;
        ProjectId = arg.ProjectId;
        CreatedBy = arg.CreatedBy;
        CreatedAt = arg.CreatedAt;
        ManagerRoleId = arg.ManagerRoleId;
    }
    public static async Task<WorkFlow> New(CreateWorkFlowArg arg)
    {
        return new WorkFlow(arg);
    }

    public void Modify(ModifyWorkFlowArg arg)
    {
        Code = arg.Code;
        Name = arg.Name;
        ModifiedAt = arg.ModifiedAt;
        ModifiedBy = arg.ModifiedBy;
    }

    public void Deactive()
    {
        ActiveStatusId = 1;
    }

    public async Task<Step> AddStep(CreateStepArg arg)
    {
        var step = await Step.New(arg);
        _step.Add(step);
        return step;

    }
    protected override string ValidateInvariants()
    {
        throw new NotImplementedException();
    }

    

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int ProjectId { get; set; }
    public long? ManagerRoleId { get; set; }

    public string? Description { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<State> States { get; set; } = new List<State>();

    private List<Step> _step = new();
    public virtual ICollection<Step> Steps => _step;
}
