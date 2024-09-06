using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3API.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterest_Interests_FkInterestId",
                table: "PersonInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterest_Persons_FkPersonId",
                table: "PersonInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterest",
                table: "PersonInterest");

            migrationBuilder.RenameTable(
                name: "PersonInterest",
                newName: "PersonInterests");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInterest_FkPersonId",
                table: "PersonInterests",
                newName: "IX_PersonInterests_FkPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInterest_FkInterestId",
                table: "PersonInterests",
                newName: "IX_PersonInterests_FkInterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests",
                column: "PersonInterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterests_Interests_FkInterestId",
                table: "PersonInterests",
                column: "FkInterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterests_Persons_FkPersonId",
                table: "PersonInterests",
                column: "FkPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterests_Interests_FkInterestId",
                table: "PersonInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterests_Persons_FkPersonId",
                table: "PersonInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests");

            migrationBuilder.RenameTable(
                name: "PersonInterests",
                newName: "PersonInterest");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInterests_FkPersonId",
                table: "PersonInterest",
                newName: "IX_PersonInterest_FkPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInterests_FkInterestId",
                table: "PersonInterest",
                newName: "IX_PersonInterest_FkInterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterest",
                table: "PersonInterest",
                column: "PersonInterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterest_Interests_FkInterestId",
                table: "PersonInterest",
                column: "FkInterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterest_Persons_FkPersonId",
                table: "PersonInterest",
                column: "FkPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
