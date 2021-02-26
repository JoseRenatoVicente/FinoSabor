using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaERP.Infra.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmailConfigs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Porta = table.Column<int>(type: "int", nullable: false),
                    UsarSSL = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfigs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmailModelos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Using = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailModelos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FornecedorEnderecos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorEnderecos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    nome_entidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_entidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    operacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valores_alterados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo_fornecedor = table.Column<int>(type: "int", nullable: false),
                    documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    situacao = table.Column<bool>(type: "bit", nullable: false),
                    id_endereco = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_FornecedorEnderecos_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "FornecedorEnderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    situacao = table.Column<bool>(type: "bit", nullable: false),
                    quantidade_estoque = table.Column<int>(type: "int", nullable: false),
                    peso = table.Column<double>(type: "float", nullable: false),
                    largura = table.Column<int>(type: "int", nullable: false),
                    altura = table.Column<int>(type: "int", nullable: false),
                    comprimento = table.Column<int>(type: "int", nullable: false),
                    id_fornecedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_categoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "Categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_id_fornecedor",
                        column: x => x.id_fornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoImagems",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    caminho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_produto = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoImagems", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProdutoImagems_Produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_id_endereco",
                table: "Fornecedores",
                column: "id_endereco");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoImagems_id_produto",
                table: "ProdutoImagems",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_id_categoria",
                table: "Produtos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_id_fornecedor",
                table: "Produtos",
                column: "id_fornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EmailConfigs");

            migrationBuilder.DropTable(
                name: "EmailModelos");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "ProdutoImagems");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "FornecedorEnderecos");
        }
    }
}
