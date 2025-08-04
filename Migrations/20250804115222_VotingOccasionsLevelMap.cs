using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineVotingSystem.Migrations
{
    /// <inheritdoc />
    public partial class VotingOccasionsLevelMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VotingOccasionsLevelMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VotingOccasionId = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VotingOccasionsLevelId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingOccasionsLevelMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingOccasionsLevelMaps_Users_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotingOccasionsLevelMaps_VotingOccasionsLevels_VotingOccasionsLevelId",
                        column: x => x.VotingOccasionsLevelId,
                        principalTable: "VotingOccasionsLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VotingOccasionsLevelMaps_PersonId",
                table: "VotingOccasionsLevelMaps",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingOccasionsLevelMaps_VotingOccasionsLevelId",
                table: "VotingOccasionsLevelMaps",
                column: "VotingOccasionsLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VotingOccasionsLevelMaps");
        }
    }
}
