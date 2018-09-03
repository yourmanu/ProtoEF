using Microsoft.EntityFrameworkCore.Migrations;

namespace ProtoEF.Migrations
{
    public partial class addJobtypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobtypes",
                columns: table => new
                {
                    JobType = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    JobYear = table.Column<int>(maxLength: 4, nullable: false),
                    CostCenter = table.Column<string>(maxLength: 10, nullable: true),
                    JobPrefix = table.Column<string>(maxLength: 10, nullable: true),
                    JobNumber = table.Column<int>(nullable: false),
                    MaxJobNumber = table.Column<int>(nullable: false),
                    JobNumberLength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobtypes", x => new { x.JobType, x.JobYear });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobtypes");
        }
    }
}
