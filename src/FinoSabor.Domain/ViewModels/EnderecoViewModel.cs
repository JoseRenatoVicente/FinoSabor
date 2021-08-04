using FinoSabor.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinoSabor.Application.ViewModels
{
    public class EnderecoViewModel : EntityBase
    {
        public string rua { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }
}
