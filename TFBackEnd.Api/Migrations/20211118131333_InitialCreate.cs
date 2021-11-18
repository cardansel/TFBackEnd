using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFBackEnd.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apps",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exitosa = table.Column<bool>(type: "bit", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idOperario = table.Column<int>(type: "int", nullable: false),
                    idApps = table.Column<int>(type: "int", nullable: false),
                    Operariosid = table.Column<int>(type: "int", nullable: true),
                    Appsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instalaciones_apps_Appsid",
                        column: x => x.Appsid,
                        principalTable: "apps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instalaciones_Operarios_Operariosid",
                        column: x => x.Operariosid,
                        principalTable: "Operarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<float>(type: "real", nullable: false),
                    idInstalacion = table.Column<int>(type: "int", nullable: false),
                    InstalacionesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Telefonos_Instalaciones_InstalacionesId",
                        column: x => x.InstalacionesId,
                        principalTable: "Instalaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instalaciones_Appsid",
                table: "Instalaciones",
                column: "Appsid");

            migrationBuilder.CreateIndex(
                name: "IX_Instalaciones_Operariosid",
                table: "Instalaciones",
                column: "Operariosid");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_InstalacionesId",
                table: "Telefonos",
                column: "InstalacionesId");
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
