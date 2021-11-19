using Microsoft.EntityFrameworkCore.Migrations;

namespace TFBackEnd.Api.Migrations
{
    public partial class SensorAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorTelefonos",
                columns: table => new
                {
                    SensorsId = table.Column<int>(type: "int", nullable: false),
                    Telefonoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorTelefonos", x => new { x.SensorsId, x.Telefonoid });
                    table.ForeignKey(
                        name: "FK_SensorTelefonos_Sensor_SensorsId",
                        column: x => x.SensorsId,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorTelefonos_Telefonos_Telefonoid",
                        column: x => x.Telefonoid,
                        principalTable: "Telefonos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorTelefonos_Telefonoid",
                table: "SensorTelefonos",
                column: "Telefonoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorTelefonos");

            migrationBuilder.DropTable(
                name: "Sensor");
        }
    }
}
