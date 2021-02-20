using Microsoft.EntityFrameworkCore.Migrations;

namespace PanningPokerServer.Migrations {
    public partial class PopulateUserTable : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.InsertData(
                table: "USER",
                columns: new string[] {"NAME", "USERNAME", "PASSWORD"},
                values: new string[] {"Teste", "Teste", "Teste"}
            );
        }
        protected override void Down(MigrationBuilder migrationBuilder) {}
    }
}
