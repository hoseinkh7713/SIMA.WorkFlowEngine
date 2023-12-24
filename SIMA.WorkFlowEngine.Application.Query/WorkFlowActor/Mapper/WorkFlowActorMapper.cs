using AutoMapper;
using SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Query.WorkFlowActor.Mapper
{
    public class WorkFlowActorMapper : Profile
    {
        public WorkFlowActorMapper()
        {
            CreateMap<Domain.Models.WorkFlowActor.Entites.WorkFlowActor, GetWorkFlowActorQueryResult>();
        }
    }
}
