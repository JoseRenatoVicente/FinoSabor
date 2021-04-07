﻿// <auto-generated />
using System;
using FinoSabor.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinoSabor.Infra.Data.Migrations
{
    [DbContext(typeof(FinoSaborContext))]
    [Migration("20210407225526_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinoSabor.Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("categoria");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Compra", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("id_fornecedor")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("id_fornecedor");

                    b.ToTable("compra");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Endereco_Fornecedor", b =>
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

                    b.Property<string>("numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rua")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("endereco_fornecedor");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_endereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("id_endereco");

                    b.ToTable("fornecedor");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Identity.Funcao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("funcao");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Identity.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("refresh_token");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Identity.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Identity.UsuarioFuncao", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoleId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("usuario_funcao");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Imagem_Produto", b =>
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

                    b.ToTable("imagem_produto");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Itens_Compra", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_compra")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_produto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<int>("valor_unitario")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_compra");

                    b.HasIndex("id_produto");

                    b.ToTable("itens_compra");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Itens_Pedido", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_pedido")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_produto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<int>("valor_unitario")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_pedido");

                    b.HasIndex("id_produto");

                    b.ToTable("itens_pedido");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Log", b =>
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

                    b.ToTable("log");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Pedido", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("data_pedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("forma_pagamento")
                        .HasColumnType("int");

                    b.Property<Guid>("id_usuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_usuario");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("data_nascimento")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("id_usuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("id_usuario")
                        .IsUnique();

                    b.ToTable("pessoa");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("altura")
                        .HasColumnType("int");

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<int>("comprimento")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_categoria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("imagem_principal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("largura")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("peso")
                        .HasColumnType("float");

                    b.Property<int>("quantidade_estoque")
                        .HasColumnType("int");

                    b.Property<int>("quantidade_minima")
                        .HasColumnType("int");

                    b.Property<string>("slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("id_categoria");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Compra", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("id_fornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Fornecedor", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Endereco_Fornecedor", "Endereco")
                        .WithMany()
                        .HasForeignKey("id_endereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Identity.UsuarioFuncao", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Identity.Funcao", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinoSabor.Domain.Entities.Identity.Funcao", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("FinoSabor.Domain.Entities.Identity.Usuario", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinoSabor.Domain.Entities.Identity.Usuario", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Imagem_Produto", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Produto", "Produto")
                        .WithMany("Imagem")
                        .HasForeignKey("id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Itens_Compra", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Compra", "Compra")
                        .WithMany("Itens")
                        .HasForeignKey("id_compra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinoSabor.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Itens_Pedido", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("id_pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinoSabor.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Identity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Pessoa", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Identity.Usuario", "Usuario")
                        .WithOne("Pessoa")
                        .HasForeignKey("FinoSabor.Domain.Entities.Pessoa", "id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Produto", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("id_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Identity.Funcao", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Identity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Identity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("FinoSabor.Domain.Entities.Identity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Compra", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Identity.Funcao", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Identity.Usuario", b =>
                {
                    b.Navigation("Pessoa");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("FinoSabor.Domain.Entities.Produto", b =>
                {
                    b.Navigation("Imagem");
                });
#pragma warning restore 612, 618
        }
    }
}
