﻿using SistemaERP.Domain.Entities.Base;

namespace SistemaERP.Domain.Entities
{
    public class EmailConfig : EntityBase
    {
        public int Prioridade { get; set; }
        public string Host { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Porta { get; set; }
        public bool UsarSSL { get; set; }
    }
}
