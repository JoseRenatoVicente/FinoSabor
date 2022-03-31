using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Application.ViewModels
{
    public class ProdutoInsertViewModel : EntityBase
    {
        public string nome { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
        public int quantidade_estoque { get; set; }
        public int quantidade_minima { get; set; }

        //Banco de dados
        public Guid id_categoria { get; set; }
    }
}
