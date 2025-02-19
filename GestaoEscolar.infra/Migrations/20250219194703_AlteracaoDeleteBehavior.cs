using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoEscolar.infra.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Conteudo_Materia_MateriaId",
                table: "Conteudo");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaProfessor_Materia_MateriaId",
                table: "MateriaProfessor");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaProfessor_Profressor_ProfessorId",
                table: "MateriaProfessor");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaTurma_Materia_MateriaId",
                table: "MateriaTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaTurma_Turma_TurmaId",
                table: "MateriaTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Aluno_AlunoId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Materia_MateriaId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Profressor_ProfessorId",
                table: "ProfessorTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Turma_TurmaId",
                table: "ProfessorTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conteudo_Materia_MateriaId",
                table: "Conteudo",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaProfessor_Materia_MateriaId",
                table: "MateriaProfessor",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaProfessor_Profressor_ProfessorId",
                table: "MateriaProfessor",
                column: "ProfessorId",
                principalTable: "Profressor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaTurma_Materia_MateriaId",
                table: "MateriaTurma",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaTurma_Turma_TurmaId",
                table: "MateriaTurma",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Aluno_AlunoId",
                table: "Nota",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Materia_MateriaId",
                table: "Nota",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Profressor_ProfessorId",
                table: "ProfessorTurma",
                column: "ProfessorId",
                principalTable: "Profressor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Turma_TurmaId",
                table: "ProfessorTurma",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Conteudo_Materia_MateriaId",
                table: "Conteudo");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaProfessor_Materia_MateriaId",
                table: "MateriaProfessor");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaProfessor_Profressor_ProfessorId",
                table: "MateriaProfessor");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaTurma_Materia_MateriaId",
                table: "MateriaTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaTurma_Turma_TurmaId",
                table: "MateriaTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Aluno_AlunoId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Materia_MateriaId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Profressor_ProfessorId",
                table: "ProfessorTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Turma_TurmaId",
                table: "ProfessorTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Conteudo_Materia_MateriaId",
                table: "Conteudo",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaProfessor_Materia_MateriaId",
                table: "MateriaProfessor",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaProfessor_Profressor_ProfessorId",
                table: "MateriaProfessor",
                column: "ProfessorId",
                principalTable: "Profressor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaTurma_Materia_MateriaId",
                table: "MateriaTurma",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaTurma_Turma_TurmaId",
                table: "MateriaTurma",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Aluno_AlunoId",
                table: "Nota",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Materia_MateriaId",
                table: "Nota",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Profressor_ProfessorId",
                table: "ProfessorTurma",
                column: "ProfessorId",
                principalTable: "Profressor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Turma_TurmaId",
                table: "ProfessorTurma",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
