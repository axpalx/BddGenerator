using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bddgenerator.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(1000)", maxLength: 1000, nullable: false, comment: "Descrição do projeto"),
                    Quantidade_Sprint = table.Column<int>(type: "INT", nullable: false, comment: "Quantidade de sprints que o projeto irá ter"),
                    Nome = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false, comment: "Nome do projeto"),
                    Data_Criacao = table.Column<DateTime>(type: "DATETIME", nullable: false, comment: "Data em que o projeto foi criado no sistema"),
                    Criado_Por = table.Column<string>(type: "NVARCHAR(254)", maxLength: 254, nullable: false, comment: "Nome de quem criou o projeto no sistema")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                },
                comment: "Tabela de Projeto");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Código do usuário"),
                    Email = table.Column<string>(type: "NVARCHAR(254)", maxLength: 254, nullable: false, comment: "E-mail do usuário"),
                    Senha = table.Column<string>(type: "NVARCHAR(84)", maxLength: 84, nullable: false, comment: "Senha do usuário"),
                    Status = table.Column<bool>(type: "BIT", nullable: false, comment: "Indica se o usuário está ativo ou inativo"),
                    Nome = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false, comment: "Nome do usuário"),
                    Data_Criacao = table.Column<DateTime>(type: "DATETIME", nullable: false, comment: "Data em que o usuário foi criado"),
                    Criado_Por = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                },
                comment: "Tabela de usuário");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_Nome",
                table: "Projeto",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuário_Nome",
                table: "Usuario",
                column: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
