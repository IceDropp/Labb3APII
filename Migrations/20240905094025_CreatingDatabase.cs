using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3API.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Interests_FkInterestId",
                        column: x => x.FkInterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterest",
                columns: table => new
                {
                    PersonInterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkPersonId = table.Column<int>(type: "int", nullable: false),
                    FkInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterest", x => x.PersonInterestId);
                    table.ForeignKey(
                        name: "FK_PersonInterest_Interests_FkInterestId",
                        column: x => x.FkInterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterest_Persons_FkPersonId",
                        column: x => x.FkPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_FkInterestId",
                table: "Links",
                column: "FkInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterest_FkInterestId",
                table: "PersonInterest",
                column: "FkInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterest_FkPersonId",
                table: "PersonInterest",
                column: "FkPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterest");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
