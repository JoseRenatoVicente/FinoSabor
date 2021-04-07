using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Domain.Entities
{
    public class Log : EntityBase
    {
        public Guid? id_usuario { get; set; }
        public Guid id_entidade { get; set; }
        public string nome_entidade { get; set; }
        public string operacao { get; set; }
        public string valores_alterados { get; set; }
        public DateTime? data_cadastro { get; set; } = DateTime.UtcNow;
    }
}
