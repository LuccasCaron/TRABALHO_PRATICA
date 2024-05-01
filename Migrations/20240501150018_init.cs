using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROJETO_ADVOCACIA.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advogados",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(30)", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advogados", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(40)", nullable: false),
                    Telephone = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "varchar(30)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estagiarios",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(30)", nullable: false),
                    CpfAdvogado = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estagiarios", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Estagiarios_Advogados_CpfAdvogado",
                        column: x => x.CpfAdvogado,
                        principalTable: "Advogados",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CpfCliente = table.Column<string>(type: "varchar(15)", nullable: false),
                    CpfAdvogado = table.Column<string>(type: "varchar(15)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Descrição = table.Column<string>(type: "varchar(255)", nullable: false),
                    Data_Abertura = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processos_Advogados_CpfAdvogado",
                        column: x => x.CpfAdvogado,
                        principalTable: "Advogados",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Processos_Clientes_CpfCliente",
                        column: x => x.CpfCliente,
                        principalTable: "Clientes",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CpfResponsavel = table.Column<string>(type: "varchar(20)", nullable: false),
                    ISBN_Livro = table.Column<string>(type: "varchar(30)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Data_Emprestimo = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Livros_ISBN_Livro",
                        column: x => x.ISBN_Livro,
                        principalTable: "Livros",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Custas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    IdProcesso = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: false),
                    Data_Custa = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Custas_Processos_IdProcesso",
                        column: x => x.IdProcesso,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Custas_IdProcesso",
                table: "Custas",
                column: "IdProcesso");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_ISBN_Livro",
                table: "Emprestimos",
                column: "ISBN_Livro");

            migrationBuilder.CreateIndex(
                name: "IX_Estagiarios_CpfAdvogado",
                table: "Estagiarios",
                column: "CpfAdvogado");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_CpfAdvogado",
                table: "Processos",
                column: "CpfAdvogado");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_CpfCliente",
                table: "Processos",
                column: "CpfCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Custas");

            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "Estagiarios");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Advogados");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
