﻿using Sima.Framework.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Contract.WorkFlow
{
    public class DeleteWorkFlowCommand : ICommand<long>
    {
        public int Id { get; set; }
    }
}
