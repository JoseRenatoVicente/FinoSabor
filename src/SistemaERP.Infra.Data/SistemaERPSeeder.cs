using SistemaERP.Domain.Entities;
using SistemaERP.Domain.Entities.Enums;
using System;
using System.Linq;

namespace SistemaERP.Infra.Data
{
    public class SistemaERPSeeder
    {
        private readonly SistemaERPContext _context;

        public SistemaERPSeeder(SistemaERPContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            //_context.Database.EnsureCreated();

            if (_context.Produtos.Any() ||
                _context.Categorias.Any() ||
                _context.Fornecedores.Any())
            {
                return;
            }
            Endereco_Fornecedor e1 = new Endereco_Fornecedor("d", "10", "complemento", "13432123", "", "", "");

            Fornecedor f1 = new Fornecedor("Nestle", TipoFornecedor.PessoaFisica, "32067903012", true, e1.id);
            Fornecedor f2 = new Fornecedor("Coca-Cola", TipoFornecedor.PessoaFisica, "75112514043", true, e1.id);

            Categoria c1 = new Categoria("Doces");
            Categoria c2 = new Categoria("Chocolate");

            EmailConfig email1 = new EmailConfig
            {
                Host = "smtp.gmail.com",
                Email = "tempforum333@gmail.com",
                Senha = "3t3wi7ez",
                Prioridade = 1,
                UsarSSL = true,
                Porta = 587
            };


            _context.EmailConfigs.AddRange(email1);
            _context.Fornecedores.AddRange(f1, f2);
            _context.Categorias.AddRange(c1, c2);
            _context.FornecedorEnderecos.AddRange(e1);


            for (int i = 0; i < 200; i++)
            {
                Produto p1 = new Produto("Nutella", 30, "Nutella possui um sabor autêntico de avelã e cacau e sua cremosidade única intensifica o sabor. É tão delicioso que mesmo em pequenas quantidades é altamente satisfatório: 20g/1 colher de sopa de creme Nutella no pão é o suficiente ..."
                    , true, 51, 10, 100, 12, 20, f1.id, c2.id);
                Categoria c3 = new Categoria("Doces");
                Fornecedor f3 = new Fornecedor("Coca-Cola", TipoFornecedor.PessoaFisica, "75112514043", true, e1.id);
                _context.Fornecedores.AddRange(f3);
                _context.Produtos.AddRange(p1);
                _context.Categorias.AddRange(c3);
            }



            _context.SaveChanges();
        }
    }
}
