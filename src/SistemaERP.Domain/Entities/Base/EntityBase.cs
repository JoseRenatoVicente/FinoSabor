using System;

namespace SistemaERP.Domain.Entities.Base
{
    public abstract class EntityBase 
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime? DataCadastro { get; set; } = DateTime.Now;

    }
}
