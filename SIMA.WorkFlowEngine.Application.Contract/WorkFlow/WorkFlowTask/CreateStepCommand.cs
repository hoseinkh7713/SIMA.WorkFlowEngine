﻿using Sima.Framework.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Contract.WorkFlow.WorkFlowTask
{
    public class CreateStepCommand : ICommand<long>
    {
        public List<int> ActorId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public long? MainEntityId { get; set; }
        public int? WorkFlowId { get; set; }
        public int? StateId { get; set; }
        public int? StepNumber { get; set; }
        public int? RejectStepNumber { get; set; }
        public int? NextStepNumber { get; set; }
        public string? IsActive { get; set; }
        public string? IsLastStep { get; set; }
        public int? AttachmentCountLimitation { get; set; }
        public string? IsAttachmentRequired { get; set; }
        public string? IsSetReciverRequired { get; set; }
        public string? Description { get; set; }
        public int? ActiveStatusId { get; set; }
    }
}
