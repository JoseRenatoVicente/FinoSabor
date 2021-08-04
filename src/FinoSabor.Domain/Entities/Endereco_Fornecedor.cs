using FinoSabor.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class Endereco_Fornecedor : EntityBase
    {

        public Endereco_Fornecedor()
        {
        }

        public Endereco_Fornecedor(string rua, int numero, string complemento, string cep, string bairro, string cidade, string estado)
        {
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
            this.cep = cep;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
        }

        public string rua { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }         

    }
}