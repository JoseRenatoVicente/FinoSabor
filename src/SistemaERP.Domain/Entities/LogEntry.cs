using SistemaERP.Domain.Entities.Base;
using System;

namespace SistemaERP.Domain.Entities
{
    public class LogEntry : EntityBase
    {
        public Guid? UserId { get; set; }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public string Operation { get; set; }
        public DateTime LogDateTime { get; set; }
        public string ValuesChanges { get; set; }
    }
}
