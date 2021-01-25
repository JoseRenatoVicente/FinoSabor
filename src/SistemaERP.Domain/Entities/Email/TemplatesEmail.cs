using SistemaERP.Domain.Entities.Base;

namespace SistemaERP.Domain.Entities.Email
{
    public class TemplatesEmail : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Using { get; set; }
        //public bool Active { get; set; }
    }
}
