using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_NET_Exchange.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SingleCurrencyExchange",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    timeStamp = table.Column<int>(nullable: false),
                    nameOfCurrency = table.Column<string>(nullable: true),
                    exchangeRate = table.Column<double>(nullable: false),
                    amountToExchange = table.Column<int>(nullable: false),
                    resultOfCalculating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleCurrencyExchange", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SingleCurrencyExchange");
        }
    }
}
