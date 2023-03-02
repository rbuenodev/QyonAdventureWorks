using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Sexo = table.Column<string>(type: "text", nullable: true),
                    TemperaturaMediaCorpo = table.Column<decimal>(type: "numeric", nullable: false),
                    Peso = table.Column<decimal>(type: "numeric", nullable: false),
                    Altura = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PistasCorrida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PistasCorrida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosCorrida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataCorrida = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TempoGasto = table.Column<decimal>(type: "numeric", nullable: false),
                    CompetidorId = table.Column<int>(type: "integer", nullable: true),
                    PistaCorridaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosCorrida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricosCorrida_Competidores_CompetidorId",
                        column: x => x.CompetidorId,
                        principalTable: "Competidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricosCorrida_PistasCorrida_PistaCorridaId",
                        column: x => x.PistaCorridaId,
                        principalTable: "PistasCorrida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosCorrida_CompetidorId",
                table: "HistoricosCorrida",
                column: "CompetidorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosCorrida_PistaCorridaId",
                table: "HistoricosCorrida",
                column: "PistaCorridaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricosCorrida");

            migrationBuilder.DropTable(
                name: "Competidores");

            migrationBuilder.DropTable(
                name: "PistasCorrida");
        }
    }
}
