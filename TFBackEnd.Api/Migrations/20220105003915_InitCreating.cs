using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace TFBackEnd.Api.Migrations
{
    public partial class InitCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellido = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "text", nullable: true),
                    Modelo = table.Column<string>(type: "text", nullable: true),
                    Precio = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instalaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Exitosa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperarioId = table.Column<int>(type: "int", nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    TelefonoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instalaciones_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instalaciones_Operarios_OperarioId",
                        column: x => x.OperarioId,
                        principalTable: "Operarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instalaciones_Telefonos_TelefonoId",
                        column: x => x.TelefonoId,
                        principalTable: "Telefonos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorTelefono",
                columns: table => new
                {
                    SensoresId = table.Column<int>(type: "int", nullable: false),
                    TelefonosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorTelefono", x => new { x.SensoresId, x.TelefonosId });
                    table.ForeignKey(
                        name: "FK_SensorTelefono_Sensor_SensoresId",
                        column: x => x.SensoresId,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorTelefono_Telefonos_TelefonosId",
                        column: x => x.TelefonosId,
                        principalTable: "Telefonos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Apps",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Whatsapp" },
                    { 2, "Facebook" },
                    { 3, "Instagran" },
                    { 4, "Telegran" }
                });

            migrationBuilder.InsertData(
                table: "Operarios",
                columns: new[] { "Id", "Apellido", "Nombre" },
                values: new object[,]
                {
                    { 1, "Testing", "Testing" },
                    { 2, "Testing 2", "Testing 2" },
                    { 3, "Testing 3", "Testing 3" }
                });

            migrationBuilder.InsertData(
                table: "Sensor",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, " Giroscopio" },
                    { 2, " Movimiento" },
                    { 3, " Podometro" },
                    { 4, " Proximidad" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instalaciones_AppId",
                table: "Instalaciones",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalaciones_OperarioId",
                table: "Instalaciones",
                column: "OperarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalaciones_TelefonoId",
                table: "Instalaciones",
                column: "TelefonoId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorTelefono_TelefonosId",
                table: "SensorTelefono",
                column: "TelefonosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instalaciones");

            migrationBuilder.DropTable(
                name: "SensorTelefono");

            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "Operarios");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Telefonos");
        }
    }
}
