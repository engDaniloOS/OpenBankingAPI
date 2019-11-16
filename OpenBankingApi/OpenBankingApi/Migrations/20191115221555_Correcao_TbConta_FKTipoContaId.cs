using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenBankingApi.Migrations
{
    public partial class Correcao_TbConta_FKTipoContaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_ContaTipos_ContaTipoId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "TipoContaId",
                table: "Contas");

            migrationBuilder.AlterColumn<int>(
                name: "ContaTipoId",
                table: "Contas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_ContaTipos_ContaTipoId",
                table: "Contas",
                column: "ContaTipoId",
                principalTable: "ContaTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_ContaTipos_ContaTipoId",
                table: "Contas");

            migrationBuilder.AlterColumn<int>(
                name: "ContaTipoId",
                table: "Contas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TipoContaId",
                table: "Contas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_ContaTipos_ContaTipoId",
                table: "Contas",
                column: "ContaTipoId",
                principalTable: "ContaTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
