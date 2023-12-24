using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using SIMA.Framework.Core.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Modify;

namespace SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;

public class WorkFlowActor : Entity
{
    private WorkFlowActor()
    {

    }
    private WorkFlowActor(CreateWorkFlowActorArg arg)
    {
        Id = arg.Id;
        Name = arg.Name;
        Code = arg.Code;
        CreatedBy = arg.CreatedBy;
        CreatedAt = arg.CreatedAt;
    }
    public static async Task<WorkFlowActor> New(CreateWorkFlowActorArg arg)
    {
        var result = new WorkFlowActor(arg);
        return result;
    }

    public void Modify(ModifyWorkFlowActorArg arg)
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
    protected override string ValidateInvariants()
    {
        throw new NotImplementedException();
    }
    public void AddActorRole(List<long> roleId)
    {
        var actorRole = roleId.Select(x => WorkFlowActorRole.New(new CreateWorkFlowActorRoleArg { RoleId = x , WorkFlowActorId = Id }));
        _workFlowActorRoles.AddRange(actorRole);
    }
    public void AddActorUser(List<int> userId)
    {
        var actorUser = userId.Select(x => WorkFlowActorUser.New(new CreateWorkFlowActorUserArg { UserId = x, WorkFlowActorId = Id }));
        _workFlowActorUsers.AddRange(actorUser);
    }
    public void AddActorGroup(List<int> groupId)
    {
        var actorGroup = groupId.Select(x => WorkFlowActorGroup.New(new CreateWorkFlowActorGroupArg { GroupId = x, WorkFlowActorId = Id }));
        _workFlowActorGroups.AddRange(actorGroup);
    }
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? ActiveStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public byte[]? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    private List<WorkFlowActorRole> _workFlowActorRoles = new();
    public IReadOnlyList<WorkFlowActorRole> WorkFlowActorRoles => _workFlowActorRoles.AsReadOnly();

    public virtual ICollection<WorkFlowActorStep> WorkFlowActorSteps { get; set; } = new List<WorkFlowActorStep>();


    private List<WorkFlowActorUser> _workFlowActorUsers = new();
    public  ICollection<WorkFlowActorUser> WorkFlowActorUsers => _workFlowActorUsers.AsReadOnly();

    private List<WorkFlowActorGroup> _workFlowActorGroups = new();
    public  ICollection<WorkFlowActorGroup> WorkFlowActorGroups => _workFlowActorGroups.AsReadOnly();


}
