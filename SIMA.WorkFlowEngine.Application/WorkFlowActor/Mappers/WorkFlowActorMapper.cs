using AutoMapper;
using SIMA.WorkFlowEngine.Application.Contract.WorkFlowActor;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Args.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIMA.WorkFlowEngine.Application.WorkFlowActor.Mappers
{
    public class WorkFlowActorMapper : Profile
    {
        public WorkFlowActorMapper()
        {
            CreateMap<CreateWorkFlowActorCommand, CreateWorkFlowActorArg>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.ActiveStatusId, opt => opt.MapFrom(src => 2)
                );
        }
    }
}
