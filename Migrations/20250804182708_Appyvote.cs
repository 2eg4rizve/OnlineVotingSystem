using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineVotingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Appyvote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ApplyVotes",
                newName: "VotingOccasionsLevelId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "ApplyVotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VoterId",
                table: "ApplyVotes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "ApplyVotes");

            migrationBuilder.DropColumn(
                name: "VoterId",
                table: "ApplyVotes");

            migrationBuilder.RenameColumn(
                name: "VotingOccasionsLevelId",
                table: "ApplyVotes",
                newName: "UserId");
        }
    }
}
