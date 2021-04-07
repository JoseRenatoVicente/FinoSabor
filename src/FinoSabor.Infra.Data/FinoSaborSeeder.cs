using Microsoft.AspNetCore.Identity;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Enums;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Domain.Helpers;
using System.Linq;

namespace FinoSabor.Infra.Data
{
    public class FinoSaborSeeder
    {
        private readonly FinoSaborContext _context;
        private readonly RoleManager<Funcao> RoleManager;

        public FinoSaborSeeder(FinoSaborContext context,
                                RoleManager<Funcao> roleManager)
        {
            _context = context;
            RoleManager = roleManager;
        }

        public void Seed()
        {

            if (_context.produto.Any() ||
                _context.categoria.Any() ||
                _context.fornecedor.Any())
            {
                return;
            }

            Endereco_Fornecedor e1 = new Endereco_Fornecedor("d", "10", "complemento", "13432123", "dd", "dd", "dd");
            Endereco_Fornecedor e2 = new Endereco_Fornecedor("d", "10", "complemento", "13432123", "dd", "dd", "dd");

            Fornecedor f1 = new Fornecedor("Nestle", "23186035000162", true, e1.id);
            Fornecedor f2 = new Fornecedor("Coca-Cola", "09110832000135", true, e2.id);

            

            Categoria c1 = new Categoria("Doces");
            Categoria c2 = new Categoria("Chocolate");

            Produto produto1 = new Produto
            {
                nome = "Bomba de chocolate",
                altura = 1,
                peso = 1,
                largura = 1,
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Bomba de chocolate".Slugify(),
                id_categoria = c1.id,
                valor = 10,
                comprimento = 10,
                descricao = "Muito bom",
                ativo = true,
                
            };

            Produto produto2 = new Produto
            {
                nome = "Bolo",
                altura = 1,
                peso = 1,
                largura = 1,
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "bolo".Slugify(),
                id_categoria = c1.id,
                valor = 10,
                comprimento = 10,
                descricao = "Muito bom",
                ativo = true,

            };

            Funcao funcao1 = new Funcao
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "91f9b6c6-d6d6-44c1-b0b5-32cf7e858c62"
            };

            Funcao funcao2 = new Funcao
            {
                Name = "usuario",
                NormalizedName = "USUARIO",
                ConcurrencyStamp = "db0654f9-9428-44c6-8213-c4b99aabdb9d"
            };

            _context.Set<Funcao>().AddRange(funcao1, funcao2);

            _context.fornecedor.AddRange(f1, f2);
            _context.categoria.AddRange(c1, c2);
            _context.endereco_fornecedor.AddRange(e1, e2);
            _context.produto.AddRange(produto1, produto2);

            _context.SaveChanges();




        }
    }
}
