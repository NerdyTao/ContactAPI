using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Avatar", "Birthday", "Company", "Email", "JobTitle", "LastName", "Name", "NickName", "Notes", "Phone" },
                values: new object[,]
                {
                    { "d28888e9-2ba9-473a-a40f-e38cb54f9b35", "533 Airport blvd, suite 505, burlingame, CA 94010 ", "", "05-05-1996", "247pro", "bg@247pro.com", "SDE", "Griffin", "Berry", "BG", "Ships", "1234567890" },
                    { "c31111f2-5cqa4-156g-g20e-h62ab54f9k91", "1299 Bayshore hwy, rm 128, burlingame, CA 94010", "", "09-08-1995", "modobay", "BM@modobay.com", "SDE", "Mateo", "Ben", "Benteo", "Cars", "9876543210" },
                    { "a35555f2-5cqa4-156g-g20e-h62ab54f9k91", "1299 Bayshore hwy, rm 128, burlingame, CA 94010", "", "10-28-1994", "modobay", "PJ@modobay.com", "Designer", "Julie", "Penelope", "PJ", "Singing", "9876543210" },
                    { "f75555a2-4dd2-132d-d20d-d61dc11a2f24", "533 Airport blvd, suite 505, burlingame, CA 94010 ", "", "01-08-1991", "247pro", "mj@247pro.com", "SDE", "Jones", "Matthew", "MJ", "Bulls", "1111111111" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
