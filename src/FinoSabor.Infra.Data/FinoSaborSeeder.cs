using Microsoft.AspNetCore.Identity;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Enums;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Domain.Helpers;
using System.Linq;
using System;

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

            if (_context.produto.Any() ||
                _context.categoria.Any() ||
                _context.fornecedor.Any())
            {
                return;
            }

            Endereco_Fornecedor e1 = new Endereco_Fornecedor("d", 10, "complemento", "13432123", "dd", "dd", "dd");
            Endereco_Fornecedor e2 = new Endereco_Fornecedor("d", 10, "complemento", "13432123", "dd", "dd", "dd");

            Fornecedor f1 = new Fornecedor("Nestle", "23186035000162", true, e1.id);
            Fornecedor f2 = new Fornecedor("Coca-Cola", "09110832000135", true, e2.id);


            Categoria CategoriaBebidas = new Categoria("Bebidas");
            Categoria CategoriaSalgados = new Categoria("Salgados");
            Categoria CategoriaDoces = new Categoria("Doces");

            Produto ProdutoBolo = new Produto
            {
                id = Guid.Parse("7F5BE3B7-866D-48F8-A42A-1D020BE4072E"),
                nome = "Bolo",
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Bolo".Slugify(),
                id_categoria = CategoriaDoces.id,
                valor = 10,
                descricao = "Muito bom",
                ativo = true,
                imagem_principal = "885d3653-17c7-41ca-84d9-9b7beaaa326f_foto-bolo.jfif"
            };

            Produto ProdutoGuarana = new Produto
            {
                nome = "Guaraná Antártica - Lata",
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Guaraná Antártica - Lata".Slugify(),
                id_categoria =CategoriaBebidas.id,
                valor = 3.99M,
                descricao = "Muito bom",
                ativo = true,
                imagem_principal = "ef8af7e0-53f0-4ca8-8996-9734a8c0ab9d_guaranaantartica-foto.webp"
            };

            Produto ProdutoEsfirra = new Produto
            {
                nome = "Esfirra",
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Esfirra".Slugify(),
                id_categoria = CategoriaSalgados.id,
                valor = 4.5M,
                descricao = "Muito bom",
                ativo = true,
                imagem_principal = "e3c8f313-7441-439f-a0d9-cb389d578f06_esfirra_foto.jpg"
            };

            Produto ProdutoBombaChocolate = new Produto
            {
                nome = "Bomba de chocolate",
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Bomba de chocolate".Slugify(),
                id_categoria = CategoriaDoces.id,
                valor = 3.99M,
                descricao = "Muito bom",
                ativo = true,
                imagem_principal = "ef8af7e0-53f0-4ca8-8996-9734a8c0ab9d_guaranaantartica-foto.webp"
            };

            Produto ProdutoFanta = new Produto
            {
                nome = "Fanta - 2l",
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Fanta - 2l".Slugify(),
                id_categoria = CategoriaBebidas.id,
                valor = 8.5M,
                descricao = "Muito bom",
                ativo = true,
                imagem_principal = "35ed603a-6c30-4825-8678-7982eed4496e_fanta-2l-foto.jpg"
            };

            Produto ProdutoBauru = new Produto
            {
                nome = "Bauru",
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Bauru".Slugify(),
                id_categoria = CategoriaSalgados.id,
                valor = 4.5M,
                descricao = "Muito bom",
                ativo = true,
                imagem_principal = "93f33c4a-a389-42d0-b94a-612c2f6aa808_bauru_foto.jpg"
            };

            Produto ProdutoPudim = new Produto
            {
                nome = "Pudim de chocolate",
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Pudim de chocolate".Slugify(),
                id_categoria = CategoriaDoces.id,
                valor = 4.5M,
                descricao = "Muito bom",
                ativo = true,
                imagem_principal = "6b37d9cb-678e-43ae-8c81-b32c535659af_pudim-chocolate_foto.jpg"
            };

            Produto ProdutoCoxinha = new Produto
            {
                nome = "Coxinha",
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Coxinha".Slugify(),
                id_categoria = CategoriaBebidas.id,
                valor = 4.5M,
                descricao = "Muito bom",
                ativo = true,
                imagem_principal = "61a1db7c-4da5-43d6-b719-eefa9775e697_coxinha_foto.jpeg"
            };

            Produto ProdutoCocaCola = new Produto
            {
                nome = "Coca Cola - Lata",
                quantidade_estoque = 10,
                quantidade_minima = 5,
                slug = "Coca Cola - Lata".Slugify(),
                id_categoria = CategoriaBebidas.id,
                valor = 4.5M,
                descricao = "Muito bom",
                ativo = true,
                imagem_principal = "0e12a5ea-e95e-4f0a-908b-fb1c94b12450_cocacola-lata_foto.jpg"
            };


            Compra compra1 = new Compra
            {
                data = DateTime.Now,
                id_fornecedor = f1.id
            };

            Itens_Compra itens_Compra1 = new Itens_Compra
            {
                quantidade = 10,
                id_produto = ProdutoGuarana.id,
                valor_unitario = 10.50M,
                id_compra = compra1.id
            };

            Itens_Compra itens_Compra2 = new Itens_Compra
            {
                quantidade = 15,
                id_produto = ProdutoBombaChocolate.id,
                valor_unitario = 7.99M,
                id_compra = compra1.id
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
                cpf = "59765563884",
                telefone = "16996204177",
                rua = "Rua 1",
                bairro = "centro",
                numero = 100,
                cep = "15900017",
                cidade = "Taquaritinga",
                estado = "SP",
                data_cadastro = DateTime.Now,
                data_nascimento = DateTime.Now,
                id_usuario = usuario1.Id
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
                data_cadastro = DateTime.Now,
                id_usuario = usuario2.Id
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
                data_cadastro = DateTime.Now,
                id_usuario = usuario3.Id
            };//Fim Usuario Gustavo

            Pedido pedido1 = new Pedido
            {
                forma_pagamento = FormaPagamento.CartaoCredito,
                id_usuario = usuario1.Id,
                status = StatusPedido.Entregue,
                data_pedido = DateTime.Now
            };

            Itens_Pedido itens_Pedido1 = new Itens_Pedido
            { 
                id_pedido = pedido1.id,
                id_produto = ProdutoBauru.id,
                quantidade = 10,
                valor_unitario = ProdutoBauru.valor                

            };

            Itens_Pedido itens_Pedido2 = new Itens_Pedido
            {
                id_pedido = pedido1.id,
                id_produto = ProdutoCocaCola.id,
                quantidade = 8,
                valor_unitario = ProdutoCocaCola.valor

            };

            await _context.Set<Funcao>().AddRangeAsync(funcao1, funcao2, funcao3);
            await _context.Set<Usuario>().AddRangeAsync(usuario1, usuario2);
            await _context.Set<UsuarioFuncao>().AddRangeAsync(usuarioFuncao1, usuarioFuncao2);
            await _context.pessoa.AddRangeAsync(pessoa1, pessoa2);

            await _context.fornecedor.AddRangeAsync(f1, f2);
            await _context.categoria.AddRangeAsync(CategoriaBebidas, CategoriaDoces,CategoriaSalgados);
            await _context.endereco_fornecedor.AddRangeAsync(e1, e2);
            await _context.produto.AddRangeAsync(ProdutoBauru, ProdutoBolo, ProdutoBombaChocolate, ProdutoCocaCola, ProdutoCoxinha, ProdutoEsfirra, ProdutoFanta, ProdutoGuarana, ProdutoPudim);

            await _context.pedido.AddRangeAsync(pedido1, pedido1);
            await _context.itens_pedido.AddRangeAsync(itens_Pedido1, itens_Pedido2);

            await _context.compra.AddRangeAsync(compra1);
            await _context.itens_compra.AddRangeAsync(itens_Compra1, itens_Compra2);

            _context.SaveChanges();




        }
    }
}
