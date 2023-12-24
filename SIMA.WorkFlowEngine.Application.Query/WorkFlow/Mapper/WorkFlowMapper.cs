using AutoMapper;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlow;


namespace SIMA.WorkFlowEngine.Application.Query.WorkFlow.Mapper
{
    public class WorkFlowMapper : Profile
    {
        public WorkFlowMapper()
        {
            CreateMap<Domain.Models.WorkFlow.Entities.WorkFlow, GetWorkFlowQueryResult>();
        }
    }
}
