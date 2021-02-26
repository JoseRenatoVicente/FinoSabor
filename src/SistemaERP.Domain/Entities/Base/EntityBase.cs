using System;

namespace SistemaERP.Domain.Entities.Base
{
    public abstract class EntityBase 
    {
        protected EntityBase()
        {
            id = Guid.NewGuid();
        }

        public Guid id { get; set; }

    }
}
