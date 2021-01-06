using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    Datafim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataIni = table.Column<DateTime>(nullable: false),
                    Datafim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataIni", "DataNasc", "Datafim", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, new DateTime(2021, 1, 6, 16, 51, 5, 217, DateTimeKind.Utc).AddTicks(8705), new DateTime(2005, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataIni", "DataNasc", "Datafim", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, new DateTime(2021, 1, 6, 16, 51, 5, 218, DateTimeKind.Utc).AddTicks(1486), new DateTime(2005, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataIni", "DataNasc", "Datafim", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, new DateTime(2021, 1, 6, 16, 51, 5, 218, DateTimeKind.Utc).AddTicks(1538), new DateTime(2005, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataIni", "DataNasc", "Datafim", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, new DateTime(2021, 1, 6, 16, 51, 5, 218, DateTimeKind.Utc).AddTicks(1543), new DateTime(2005, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataIni", "DataNasc", "Datafim", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, new DateTime(2021, 1, 6, 16, 51, 5, 218, DateTimeKind.Utc).AddTicks(1546), new DateTime(2005, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataIni", "DataNasc", "Datafim", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, true, new DateTime(2021, 1, 6, 16, 51, 5, 218, DateTimeKind.Utc).AddTicks(1553), new DateTime(2005, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataIni", "DataNasc", "Datafim", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, true, new DateTime(2021, 1, 6, 16, 51, 5, 218, DateTimeKind.Utc).AddTicks(1557), new DateTime(2005, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataIni", "Datafim", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, new DateTime(2021, 1, 6, 16, 51, 5, 213, DateTimeKind.Utc).AddTicks(1929), null, "Lauro", 1, "Oliveira", "419986598" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataIni", "Datafim", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, new DateTime(2021, 1, 6, 16, 51, 5, 213, DateTimeKind.Utc).AddTicks(4806), null, "Roberto", 2, "Soares", "436546598" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataIni", "Datafim", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, new DateTime(2021, 1, 6, 16, 51, 5, 213, DateTimeKind.Utc).AddTicks(4844), null, "Ronaldo", 3, "Marconi", "449998798" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataIni", "Datafim", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, new DateTime(2021, 1, 6, 16, 51, 5, 213, DateTimeKind.Utc).AddTicks(4846), null, "Rodrigo", 4, "Carvalho", "459983218" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataIni", "Datafim", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, new DateTime(2021, 1, 6, 16, 51, 5, 213, DateTimeKind.Utc).AddTicks(4848), null, "Alexandre", 5, "Montanha", "46951998" });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 3, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 1, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5703), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 5, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5718), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 5, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5709), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 5, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5701), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 4, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5731), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 4, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5726), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 5, 4, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5719), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 4, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5717), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 4, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5668), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 3, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5730), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 5, 5, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5720), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 3, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5724), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 2, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5728), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 2, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5723), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 2, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5712), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 2, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5704), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 2, null, new DateTime(2021, 1, 6, 13, 51, 5, 218, DateTimeKind.Local).AddTicks(3006), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 1, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5727), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 1, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5721), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 1, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5715), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 1, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5711), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 3, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5713), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 5, null, new DateTime(2021, 1, 6, 13, 51, 5, 219, DateTimeKind.Local).AddTicks(5732), null });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
