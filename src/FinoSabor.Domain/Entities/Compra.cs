﻿using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace FinoSabor.Domain.Entities
{
    public class Compra : EntityBase
    {
        public DateTime Data { get; set; } = DateTime.UtcNow;

        public StatusCompra StatusCompra { get; set; }
        //Banco de dados
        public Guid FornecedorId { get; set; }

        //EF Relation
        public Fornecedor Fornecedor { get; set; }

        /* EF Relations */
        public ICollection<ItensCompra> Itens { get; set; }
    }
}
