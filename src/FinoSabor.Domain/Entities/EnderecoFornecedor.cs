using FinoSabor.Domain.Entities.Base;

namespace FinoSabor.Domain.Entities
{
    public class EnderecoFornecedor : EntityBase
    {

        public EnderecoFornecedor()
        {
        }

        public EnderecoFornecedor(string rua, int numero, string complemento, string cep, string bairro, string cidade, string estado)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }         

    }
}