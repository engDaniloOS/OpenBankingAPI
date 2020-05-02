using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenBankingApi.Migrations
{
    public partial class correcaoControleTransacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorNovo",
                table: "Transacaoes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorVelho",
                table: "Transacaoes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorNovo",
                table: "Transacaoes");

            migrationBuilder.DropColumn(
                name: "ValorVelho",
                table: "Transacaoes");
        }
    }
}
