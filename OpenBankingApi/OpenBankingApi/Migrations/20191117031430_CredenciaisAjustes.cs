using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenBankingApi.Migrations
{
    public partial class CredenciaisAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Credenciais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Credenciais_ClienteId",
                table: "Credenciais",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credenciais_Cliente_ClienteId",
                table: "Credenciais",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credenciais_Cliente_ClienteId",
                table: "Credenciais");

            migrationBuilder.DropIndex(
                name: "IX_Credenciais_ClienteId",
                table: "Credenciais");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Credenciais");
        }
    }
}
