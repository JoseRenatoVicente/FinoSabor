using SistemaERP.Domain.Entities.Base;
using System;

namespace SistemaERP.Domain.Entities
{
    public class Endereco_Fornecedor : EntityBase
    {

        public Endereco_Fornecedor()
        {
        }

        public Endereco_Fornecedor(string logradouro, string numero, string complemento, string cep, string bairro, string cidade, string estado)
        {
            this.logradouro = logradouro;
            this.numero = numero;
            this.complemento = complemento;
            this.cep = cep;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
        }

        public string logradouro { get; private set; }
        public string numero { get; private set; }
        public string complemento { get; private set; }
        public string cep { get; private set; }
        public string bairro { get; private set; }
        public string cidade { get; private set; }
        public string estado { get; private set; }
        /*public Guid id_fornecedor { get; set; }
        
        /* EF Relation */
        //public Fornecedor Fornecedor { get; private set; }
    }
}