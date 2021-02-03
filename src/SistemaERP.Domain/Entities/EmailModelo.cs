using SistemaERP.Domain.Entities.Base;

namespace SistemaERP.Domain.Entities
{
    public class EmailModelo : EntityBase
    {
        //TODO - Revisar e passar para português
        public string Name { get; set; }
        public string Code { get; set; }
        public string Using { get; set; }
    }
}
