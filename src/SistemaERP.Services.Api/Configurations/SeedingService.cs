using SistemaERP.Domain.Entities;
using SistemaERP.Domain.Entities.Enums;
using SistemaERP.Infra.Data.Context;
using System;
using System.Linq;

namespace SistemaERP.Services.Api.Configurations
{
    public class SeedingService
    {
        private SistemaERPContext _context;

        public SeedingService(SistemaERPContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Produtos.Any() ||
                _context.Categorias.Any() ||
                _context.Fornecedores.Any())
            {
                return;
            }


            Fornecedor f1 = new Fornecedor("Nestle", "32067903012", TipoFornecedor.PessoaFisica, true);
            Fornecedor f2 = new Fornecedor("Coca-Cola", "75112514043", TipoFornecedor.PessoaFisica, true);

            Categoria c1 = new Categoria("Doces", null);
            Categoria c2 = new Categoria("Chocolate", c1.Id);



            _context.Fornecedores.AddRange(f1, f2);
            _context.Categorias.AddRange(c1, c2);


            for (int i = 0; i < 200; i++)
            {
                Produto p1 = new Produto("Nutella", 30, "Nutella possui um sabor autêntico de avelã e cacau e sua cremosidade única intensifica o sabor. É tão delicioso que mesmo em pequenas quantidades é altamente satisfatório: 20g/1 colher de sopa de creme Nutella no pão é o suficiente ..."
                    , true, 51, 10, 100, 12, 20, DateTime.Now, f1.Id, c2.Id);
                Categoria c3 = new Categoria("Doces", null);
                Fornecedor f3 = new Fornecedor("Coca-Cola", "75112514043", TipoFornecedor.PessoaFisica, true);
                _context.Fornecedores.AddRange(f3);
                _context.Produtos.AddRange(p1);
                _context.Categorias.AddRange(c3);
            }

            

            _context.SaveChanges();


        }
    }
}
