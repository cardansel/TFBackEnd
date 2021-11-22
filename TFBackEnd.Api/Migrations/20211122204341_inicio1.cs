using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace TFBackEnd.Api.Migrations
{
    public partial class inicio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apps",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Operarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    apellido = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Instalaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Exitosa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    idOperario = table.Column<int>(type: "int", nullable: false),
                    idApp = table.Column<int>(type: "int", nullable: false),
                    Operarioid = table.Column<int>(type: "int", nullable: true),
                    Appid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instalaciones_apps_Appid",
                        column: x => x.Appid,
                        principalTable: "apps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instalaciones_Operarios_Operarioid",
                        column: x => x.Operarioid,
                        principalTable: "Operarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    marca = table.Column<string>(type: "text", nullable: true),
                    modelo = table.Column<string>(type: "text", nullable: true),
                    precio = table.Column<float>(type: "float", nullable: false),
                    idInstalacion = table.Column<int>(type: "int", nullable: false),
                    InstalacioneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Telefonos_Instalaciones_InstalacioneId",
                        column: x => x.InstalacioneId,
                        principalTable: "Instalaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instalaciones_Appid",
                table: "Instalaciones",
                column: "Appid");

            migrationBuilder.CreateIndex(
                name: "IX_Instalaciones_Operarioid",
                table: "Instalaciones",
                column: "Operarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_InstalacioneId",
                table: "Telefonos",
                column: "InstalacioneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Instalaciones");

            migrationBuilder.DropTable(
                name: "apps");

            migrationBuilder.DropTable(
                name: "Operarios");
        }
    }
}
