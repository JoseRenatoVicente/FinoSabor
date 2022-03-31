using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Domain.Entities
{
    public class Log : EntityBase
    {
        public Guid? UsuarioId { get; set; }
        public Guid EntidadeId { get; set; }
        public string NomeEntidade { get; set; }
        public string Operacao { get; set; }
        public string ValoresAlterados { get; set; }
        public DateTime? DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
