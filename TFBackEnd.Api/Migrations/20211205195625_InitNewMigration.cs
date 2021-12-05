using Microsoft.EntityFrameworkCore.Migrations;

namespace TFBackEnd.Api.Migrations
{
    public partial class InitNewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instalaciones_Apps_AppId",
                table: "Instalaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Instalaciones_Operarios_OperarioId",
                table: "Instalaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Instalaciones_Telefonos_TelefonoId",
                table: "Instalaciones");

            migrationBuilder.AlterColumn<int>(
                name: "TelefonoId",
                table: "Instalaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OperarioId",
                table: "Instalaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppId",
                table: "Instalaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instalaciones_Apps_AppId",
                table: "Instalaciones",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instalaciones_Operarios_OperarioId",
                table: "Instalaciones",
                column: "OperarioId",
                principalTable: "Operarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instalaciones_Telefonos_TelefonoId",
                table: "Instalaciones",
                column: "TelefonoId",
                principalTable: "Telefonos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instalaciones_Apps_AppId",
                table: "Instalaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Instalaciones_Operarios_OperarioId",
                table: "Instalaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Instalaciones_Telefonos_TelefonoId",
                table: "Instalaciones");

            migrationBuilder.AlterColumn<int>(
                name: "TelefonoId",
                table: "Instalaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OperarioId",
                table: "Instalaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppId",
                table: "Instalaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Instalaciones_Apps_AppId",
                table: "Instalaciones",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instalaciones_Operarios_OperarioId",
                table: "Instalaciones",
                column: "OperarioId",
                principalTable: "Operarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instalaciones_Telefonos_TelefonoId",
                table: "Instalaciones",
                column: "TelefonoId",
                principalTable: "Telefonos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
