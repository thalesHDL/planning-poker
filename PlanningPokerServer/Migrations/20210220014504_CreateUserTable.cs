using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PanningPokerServer.Migrations {
    public partial class CreateUserTable : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new {
                    ID = table.Column<int>(type: "int", nullable: false)
                            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "varchar(200)", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(200)", nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(name: "USER");
        }
    }
}
