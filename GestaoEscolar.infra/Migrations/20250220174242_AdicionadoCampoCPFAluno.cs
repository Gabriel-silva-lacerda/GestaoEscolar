using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoEscolar.infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoCampoCPFAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Aluno",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Aluno");
        }
    }
}
