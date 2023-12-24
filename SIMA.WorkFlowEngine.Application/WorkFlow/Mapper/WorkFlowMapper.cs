using AutoMapper;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlow;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlow.WorkFlowTask;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlowActor;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Args.Create;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.WorkFlow.Mapper
{
    public class WorkFlowMapper : Profile
    {
        public WorkFlowMapper()
        {
            CreateMap<CreateWorkFlowCommand, CreateWorkFlowArg>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.ActiveStatusId, opt => opt.MapFrom(src => 2));


            CreateMap<CreateStepCommand, CreateStepArg>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.ActiveStatusId, opt => opt.MapFrom(src => 2));
        }
    }
}
