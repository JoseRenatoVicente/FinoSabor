using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Enums;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Domain.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
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

        public async void Seed()
        {

            if (_context.Produto.Any() ||
                _context.Categoria.Any() ||
                _context.Fornecedore.Any())
            {
                return;
            }

            EnderecoFornecedor e1 = new EnderecoFornecedor("d", 10, "complemento", "13432123", "dd", "dd", "dd");
            EnderecoFornecedor e2 = new EnderecoFornecedor("d", 10, "complemento", "13432123", "dd", "dd", "dd");

            Fornecedor f1 = new Fornecedor("Nestle", "23186035000162", true, e1.Id);
            Fornecedor f2 = new Fornecedor("Coca-Cola", "09110832000135", true, e2.Id);


            Categoria CategoriaBebidas = new Categoria("Bebidas");
            Categoria CategoriaSalgados = new Categoria("Salgados");
            Categoria CategoriaDoces = new Categoria("Doces");

            Produto ProdutoBolo = new Produto
            {
                Id = Guid.Parse("7F5BE3B7-866D-48F8-A42A-1D020BE4072E"),
                Nome = "Bolo",
                QuantidadeEstoque = 10,
                QuantidadeMinima = 5,
                Slug = "Bolo".Slugify(),
                CategoriaId = CategoriaDoces.Id,
                Valor = 10,
                Descricao = "Muito bom",
                Ativo = true,
                ImagemPrincipal = "885d3653-17c7-41ca-84d9-9b7beaaa326f_foto-bolo.jfif"
            };

            Produto ProdutoGuarana = new Produto
            {
                Nome = "Guaraná Antártica - Lata",
                QuantidadeEstoque = 10,
                QuantidadeMinima = 5,
                Slug = "Guaraná Antártica - Lata".Slugify(),
                CategoriaId = CategoriaBebidas.Id,
                Valor = 3.99M,
                Descricao = "Muito bom",
                Ativo = true,
                ImagemPrincipal = "ef8af7e0-53f0-4ca8-8996-9734a8c0ab9d_guaranaantartica-foto.webp"
            };

            Produto ProdutoEsfirra = new Produto
            {
                Nome = "Esfirra",
                QuantidadeEstoque = 10,
                QuantidadeMinima = 5,
                Slug = "Esfirra".Slugify(),
                CategoriaId = CategoriaSalgados.Id,
                Valor = 4.5M,
                Descricao = "Muito bom",
                Ativo = true,
                ImagemPrincipal = "e3c8f313-7441-439f-a0d9-cb389d578f06_esfirra_foto.jpg"
            };

            Produto ProdutoBombaChocolate = new Produto
            {
                Nome = "Bomba de chocolate",
                QuantidadeEstoque = 10,
                QuantidadeMinima = 5,
                Slug = "Bomba de chocolate".Slugify(),
                CategoriaId = CategoriaDoces.Id,
                Valor = 3.99M,
                Descricao = "Muito bom",
                Ativo = true,
                ImagemPrincipal = "ef8af7e0-53f0-4ca8-8996-9734a8c0ab9d_guaranaantartica-foto.webp"
            };

            Produto ProdutoFanta = new Produto
            {
                Nome = "Fanta - 2l",
                QuantidadeEstoque = 10,
                QuantidadeMinima = 5,
                Slug = "Fanta - 2l".Slugify(),
                CategoriaId = CategoriaBebidas.Id,
                Valor = 8.5M,
                Descricao = "Muito bom",
                Ativo = true,
                ImagemPrincipal = "35ed603a-6c30-4825-8678-7982eed4496e_fanta-2l-foto.jpg"
            };

            Produto ProdutoBauru = new Produto
            {
                Nome = "Bauru",
                QuantidadeEstoque = 10,
                QuantidadeMinima = 5,
                Slug = "Bauru".Slugify(),
                CategoriaId = CategoriaSalgados.Id,
                Valor = 4.5M,
                Descricao = "Muito bom",
                Ativo = true,
                ImagemPrincipal = "93f33c4a-a389-42d0-b94a-612c2f6aa808_bauru_foto.jpg"
            };

            Produto ProdutoPudim = new Produto
            {
                Nome = "Pudim de chocolate",
                QuantidadeEstoque = 10,
                QuantidadeMinima = 5,
                Slug = "Pudim de chocolate".Slugify(),
                CategoriaId = CategoriaDoces.Id,
                Valor = 4.5M,
                Descricao = "Muito bom",
                Ativo = true,
                ImagemPrincipal = "6b37d9cb-678e-43ae-8c81-b32c535659af_pudim-chocolate_foto.jpg"
            };

            Produto ProdutoCoxinha = new Produto
            {
                Nome = "Coxinha",
                QuantidadeEstoque = 10,
                QuantidadeMinima = 5,
                Slug = "Coxinha".Slugify(),
                CategoriaId = CategoriaBebidas.Id,
                Valor = 4.5M,
                Descricao = "Muito bom",
                Ativo = true,
                ImagemPrincipal = "61a1db7c-4da5-43d6-b719-eefa9775e697_coxinha_foto.jpeg"
            };

            Produto ProdutoCocaCola = new Produto
            {
                Nome = "Coca Cola - Lata",
                QuantidadeEstoque = 10,
                QuantidadeMinima = 5,
                Slug = "Coca Cola - Lata".Slugify(),
                CategoriaId = CategoriaBebidas.Id,
                Valor = 4.5M,
                Descricao = "Muito bom",
                Ativo = true,
                ImagemPrincipal = "0e12a5ea-e95e-4f0a-908b-fb1c94b12450_cocacola-lata_foto.jpg"
            };


            Compra compra1 = new Compra
            {
                Data = DateTime.Now,
                FornecedorId = f1.Id
            };

            ItensCompra itens_Compra1 = new ItensCompra
            {
                Quantidade = 10,
                ProdutoId = ProdutoGuarana.Id,
                ValorUnitario = 10.50M,
                CompraId = compra1.Id
            };

            ItensCompra itens_Compra2 = new ItensCompra
            {
                Quantidade = 15,
                ProdutoId = ProdutoBombaChocolate.Id,
                ValorUnitario = 7.99M,
                CompraId = compra1.Id
            };


            Funcao funcao1 = new Funcao
            {
                Id = Guid.Parse("4EFE97B7-493D-4EAF-BA0B-7407C76C6803"),
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "91f9b6c6-d6d6-44c1-b0b5-32cf7e858c62"
            };

            Funcao funcao2 = new Funcao
            {
                Id = Guid.Parse("490018AD-BCD6-4AA9-EC4A-08D9247FB19A"),
                Name = "usuario",
                NormalizedName = "USUARIO",
                ConcurrencyStamp = "db0654f9-9428-44c6-8213-c4b99aabdb9d"
            };

            Funcao funcao3 = new Funcao
            {
                Name = "funcionario",
                NormalizedName = "FUNCIONARIO",
                ConcurrencyStamp = "665f9ff1-648c-4002-aa9e-8d4128eca346"
            };

            //Usuario José

            Usuario usuario1 = new Usuario
            {
                Id = Guid.NewGuid(),
                UserName = "josetq12@gmail.com",
                NormalizedUserName = "JOSETQ12@GMAIL.COM",
                Email = "josetq12@gmail.com",
                NormalizedEmail = "JOSETQ12@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAENmswSauhdz59qEIa9cVnM/l3IOG4xMP2voN/ikrL1eYlTneVX+A7PjmSSA52FuCnQ==",
                SecurityStamp = "VKRGUP64LZIHUPN53QZ3J2MQJEAWLDFX",
                ConcurrencyStamp = "cdf5b172-e632-438c-a48d-7c8a54aaff26",
                LockoutEnabled = true
            };


            UsuarioFuncao usuarioFuncao1 = new UsuarioFuncao
            {
                UserId = usuario1.Id,
                RoleId = funcao1.Id

            };

            Pessoa pessoa1 = new Pessoa
            {
                Nome = "José",
                CPF = "59765563884",
                Telefone = "16996204177",
                Rua = "Rua 1",
                Bairro = "centro",
                Numero = 100,
                Cep = "15900017",
                Cidade = "Taquaritinga",
                Estado = "SP",
                DataCadastro = DateTime.Now,
                DataNascimento = DateTime.Now,
                UsuarioId = usuario1.Id
            };

            //Usuario Felps

            Usuario usuario2 = new Usuario
            {
                Id = Guid.NewGuid(),
                UserName = "felpsclash2307@gmail.com",
                NormalizedUserName = "FELPSCLASH2307@GMAIL.COM",
                Email = "felpsclash2307@gmail.com",
                NormalizedEmail = "FELPSCLASH2307@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEF5cj7kh2EyfzHsuSAKu2WRA351CNHLONdxrQkwDAlnaM1cr27O6UJwlOmyWBWetrA==",
                SecurityStamp = "VM2EQA2VSCXAIBQ7IFK4HPS2RC74IYK5",
                ConcurrencyStamp = "374f6903-42db-4587-a4a1-10af58bf495e",
                LockoutEnabled = true

            };

            UsuarioFuncao usuarioFuncao2 = new UsuarioFuncao
            {
                UserId = usuario2.Id,
                RoleId = funcao1.Id

            };

            Pessoa pessoa2 = new Pessoa
            {
                Nome = "Felipe",
                DataCadastro = DateTime.Now,
                UsuarioId = usuario2.Id
            };//Fim Usuario Felps

            //Usuario Gustavo

            Usuario usuario3 = new Usuario
            {
                Id = Guid.NewGuid(),
                UserName = "ghenriquematos1@gmail.com",
                NormalizedUserName = "FELPSCLASH2307@GMAIL.COM",
                Email = "felpsclash2307@gmail.com",
                NormalizedEmail = "FELPSCLASH2307@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEF5cj7kh2EyfzHsuSAKu2WRA351CNHLONdxrQkwDAlnaM1cr27O6UJwlOmyWBWetrA==",
                SecurityStamp = "VM2EQA2VSCXAIBQ7IFK4HPS2RC74IYK5",
                ConcurrencyStamp = "374f6903-42db-4587-a4a1-10af58bf495e",
                LockoutEnabled = true

            };

            UsuarioFuncao usuarioFuncao3 = new UsuarioFuncao
            {
                UserId = usuario3.Id,
                RoleId = funcao1.Id

            };

            Pessoa pessoa3 = new Pessoa
            {
                Nome = "Gustavo",
                DataCadastro = DateTime.Now,
                UsuarioId = usuario3.Id
            };//Fim Usuario Gustavo

            Pedido pedido1 = new Pedido
            {
                FormaPagamento = FormaPagamento.CartaoCredito,
                UsuarioId = usuario1.Id,
                Status = StatusPedido.Entregue,
                DataPedido = DateTime.Now
            };

            ItensPedido itens_Pedido1 = new ItensPedido
            {
                PedidoId = pedido1.Id,
                ProdutoId = ProdutoBauru.Id,
                Quantidade = 10,
                ValorUnitario = ProdutoBauru.Valor

            };

            ItensPedido itens_Pedido2 = new ItensPedido
            {
                PedidoId = pedido1.Id,
                ProdutoId = ProdutoCocaCola.Id,
                Quantidade = 8,
                ValorUnitario = ProdutoCocaCola.Valor

            };

            await _context.Set<Funcao>().AddRangeAsync(funcao1, funcao2, funcao3);
            await _context.Set<Usuario>().AddRangeAsync(usuario1, usuario2);
            await _context.Set<UsuarioFuncao>().AddRangeAsync(usuarioFuncao1, usuarioFuncao2);
            await _context.Pessoa.AddRangeAsync(pessoa1, pessoa2);

            await _context.Fornecedore.AddRangeAsync(f1, f2);
            await _context.Categoria.AddRangeAsync(CategoriaBebidas, CategoriaDoces, CategoriaSalgados);
            await _context.EnderecoFornecedore.AddRangeAsync(e1, e2);
            await _context.Produto.AddRangeAsync(ProdutoBauru, ProdutoBolo, ProdutoBombaChocolate, ProdutoCocaCola, ProdutoCoxinha, ProdutoEsfirra, ProdutoFanta, ProdutoGuarana, ProdutoPudim);

            await _context.Pedido.AddRangeAsync(pedido1, pedido1);
            await _context.ItensPedido.AddRangeAsync(itens_Pedido1, itens_Pedido2);

            await _context.Compra.AddRangeAsync(compra1);
            await _context.ItensCompra.AddRangeAsync(itens_Compra1, itens_Compra2);

            _context.SaveChanges();




        }
    }
}
