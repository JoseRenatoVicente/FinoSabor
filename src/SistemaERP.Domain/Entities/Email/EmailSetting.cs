using SistemaERP.Domain.Entities.Base;

namespace SistemaERP.Domain.Entities.Email
{
    public class EmailSetting : EntityBase
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
