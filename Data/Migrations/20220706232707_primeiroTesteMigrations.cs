using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class primeiroTesteMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.CreateTable(
                name: "escola",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userName = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    password = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escola", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "responsavel",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    endereco = table.Column<string>(type: "NVARCHAR", maxLength: 15, nullable: false),
                    cpf = table.Column<int>(type: "NVARCHAR", maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responsavel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    placa = table.Column<string>(type: "NVARCHAR", maxLength: 15, nullable: false),
                    ano = table.Column<int>(type: "NVARCHAR", maxLength: 10, nullable: false),
                    cor = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "motorista",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    cpf = table.Column<string>(type: "NVARCHAR", maxLength: 15, nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR", maxLength: 18, nullable: false),
                    email = table.Column<string>(type: "NVARCHAR", maxLength: 155, nullable: false),
                    veiculoId = table.Column<int>(type: "Integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motorista", x => x.id);
                    table.ForeignKey(
                        name: "FK_Motorista_Veiculo",
                        column: x => x.veiculoId,
                        principalTable: "veiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userName = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    password = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    escolaId = table.Column<int>(type: "INTEGER", nullable: false),
                    motoristaId = table.Column<int>(type: "INTEGER", nullable: false),
                    responsavelId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.id);
                    table.ForeignKey(
                        name: "FK_Aluno_Escola",
                        column: x => x.escolaId,
                        principalTable: "escola",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Motorista",
                        column: x => x.motoristaId,
                        principalTable: "motorista",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Responsavel",
                        column: x => x.responsavelId,
                        principalTable: "responsavel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cnpj = table.Column<string>(type: "TEXT", nullable: true),
                    alunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    MotoristaID = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsavelID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x.id);
                    table.ForeignKey(
                        name: "FK_Aluno_Servico",
                        column: x => x.alunoId,
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_servico_motorista_MotoristaID",
                        column: x => x.MotoristaID,
                        principalTable: "motorista",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servico_responsavel_ResponsavelID",
                        column: x => x.ResponsavelID,
                        principalTable: "responsavel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aluno_escolaId",
                table: "aluno",
                column: "escolaId");

            migrationBuilder.CreateIndex(
                name: "IX_aluno_motoristaId",
                table: "aluno",
                column: "motoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_aluno_responsavelId",
                table: "aluno",
                column: "responsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_motorista_veiculoId",
                table: "motorista",
                column: "veiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_servico_alunoId",
                table: "servico",
                column: "alunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_servico_MotoristaID",
                table: "servico",
                column: "MotoristaID");

            migrationBuilder.CreateIndex(
                name: "IX_servico_ResponsavelID",
                table: "servico",
                column: "ResponsavelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "servico");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "escola");

            migrationBuilder.DropTable(
                name: "motorista");

            migrationBuilder.DropTable(
                name: "responsavel");

            migrationBuilder.DropTable(
                name: "veiculo");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    userName = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }
    }
}
