﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaERP.Infra.Data;

namespace SistemaERP.Infra.Data.Migrations
{
    [DbContext(typeof(SistemaERPContext))]
    [Migration("20210226004517_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaERP.Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("data_nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.EmailConfig", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Host")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Porta")
                        .HasColumnType("int");

                    b.Property<int>("Prioridade")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UsarSSL")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("EmailConfigs");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.EmailModelo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Using")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("EmailModelos");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Endereco_Fornecedor", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("FornecedorEnderecos");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_endereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("situacao")
                        .HasColumnType("bit");

                    b.Property<int>("tipo_fornecedor")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_endereco");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Imagem_Produto", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("caminho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_produto")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("id_produto");

                    b.ToTable("ProdutoImagems");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Log", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("data_cadastro")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("id_entidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("id_usuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nome_entidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("operacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("valores_alterados")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("altura")
                        .HasColumnType("int");

                    b.Property<int>("comprimento")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_categoria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_fornecedor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("largura")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("peso")
                        .HasColumnType("float");

                    b.Property<int>("quantidade_estoque")
                        .HasColumnType("int");

                    b.Property<bool>("situacao")
                        .HasColumnType("bit");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("id_categoria");

                    b.HasIndex("id_fornecedor");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Fornecedor", b =>
                {
                    b.HasOne("SistemaERP.Domain.Entities.Endereco_Fornecedor", "Endereco")
                        .WithMany()
                        .HasForeignKey("id_endereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Imagem_Produto", b =>
                {
                    b.HasOne("SistemaERP.Domain.Entities.Produto", "Produto")
                        .WithMany("Imagem")
                        .HasForeignKey("id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Produto", b =>
                {
                    b.HasOne("SistemaERP.Domain.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("id_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaERP.Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("id_fornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("SistemaERP.Domain.Entities.Produto", b =>
                {
                    b.Navigation("Imagem");
                });
#pragma warning restore 612, 618
        }
    }
}