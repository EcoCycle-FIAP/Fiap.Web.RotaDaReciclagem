using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.RotaDaReciclagem.Migrations
{
    /// <inheritdoc />
    public partial class AddAgendamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Data = table.Column<DateTime>(type: "DATE", nullable: false),
                    TipoResiduo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    QuantidadeLitros = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CaminhaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MoradorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Caminhoes_CaminhaoId",
                        column: x => x.CaminhaoId,
                        principalTable: "Caminhoes",
                        principalColumn: "CaminhaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Moradores_MoradorId",
                        column: x => x.MoradorId,
                        principalTable: "Moradores",
                        principalColumn: "MoradorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_CaminhaoId",
                table: "Agendamentos",
                column: "CaminhaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_MoradorId",
                table: "Agendamentos",
                column: "MoradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");
        }
    }
}
