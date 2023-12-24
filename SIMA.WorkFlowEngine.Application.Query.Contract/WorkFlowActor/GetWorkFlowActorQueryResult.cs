using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Query.Contract.WorkFlowActor
{
    public class GetWorkFlowActorQueryResult
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        public int? ActiveStatusId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public byte[]? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
