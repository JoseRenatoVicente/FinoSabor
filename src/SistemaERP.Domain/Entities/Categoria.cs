using SistemaERP.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaERP.Domain.Entities
{
    public class Categoria : EntityBase
    {

        public Categoria()
        {
                
        }

        public Categoria(string nome, Guid? categoriaPaiId)
        {
            Nome = nome;
            CategoriaPaiId = categoriaPaiId;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]

        public string Nome { get; set; }

        /*
         * Auto-relacionamento
         * 1-Informatica - P:null
         * - 2-Mouse: P:1
         * -- 3-Mouse sem fio P:2
         * -- 4-Mouse Gamer P:2
         */

        public Guid? CategoriaPaiId { get; set; }


        //EF Relation
        public virtual Categoria CategoriaPai { get; set; }

    }
}
