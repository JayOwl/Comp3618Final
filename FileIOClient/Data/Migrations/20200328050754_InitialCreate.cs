using Microsoft.EntityFrameworkCore.Migrations;

namespace FileIOClient.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speeds",
                columns: table => new
                {
                    SpeedId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpeedMS = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speeds", x => x.SpeedId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speeds");
        }
    }
}
