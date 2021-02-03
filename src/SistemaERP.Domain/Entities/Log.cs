using SistemaERP.Domain.Entities.Base;
using System;

namespace SistemaERP.Domain.Entities
{
    public class Log : EntityBase
    {


        public Guid? UsuarioId { get; set; }
        public string NomeEntidade { get; set; }
        public Guid EntidadeId { get; set; }
        public string Operação { get; set; }
        //public DateTime LogDateTime { get; set; }
        public string ValoresAlterados { get; set; }

        public DateTime? DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
