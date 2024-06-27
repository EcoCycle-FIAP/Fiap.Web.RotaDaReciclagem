using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.RotaDaReciclagem.Migrations
{
    /// <inheritdoc />
    public partial class AddRotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rotas",
                columns: table => new
                {
                    RotaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PontosDeColeta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HorarioInicial = table.Column<DateTime>(type: "DATE", nullable: false),
                    HorarioFinal = table.Column<DateTime>(type: "DATE", nullable: false),
                    CaminhaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotas", x => x.RotaId);
                    table.ForeignKey(
                        name: "FK_Rotas_Caminhoes_CaminhaoId",
                        column: x => x.CaminhaoId,
                        principalTable: "Caminhoes",
                        principalColumn: "CaminhaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_CaminhaoId",
                table: "Rotas",
                column: "CaminhaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rotas");
        }
    }
}
