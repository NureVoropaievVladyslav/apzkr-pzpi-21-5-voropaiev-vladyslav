using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatePonds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PondId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pond",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FishSpecies = table.Column<int>(type: "integer", nullable: false),
                    FishPopulation = table.Column<int>(type: "integer", nullable: false),
                    FeedingScheduleId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pond", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedingSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PondId = table.Column<Guid>(type: "uuid", nullable: false),
                    FeedingFrequencyInHours = table.Column<int>(type: "integer", nullable: false),
                    FoodAmount = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedingSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedingSchedule_Pond_PondId",
                        column: x => x.PondId,
                        principalTable: "Pond",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PondId",
                table: "Users",
                column: "PondId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedingSchedule_PondId",
                table: "FeedingSchedule",
                column: "PondId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pond_PondId",
                table: "Users",
                column: "PondId",
                principalTable: "Pond",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pond_PondId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FeedingSchedule");

            migrationBuilder.DropTable(
                name: "Pond");

            migrationBuilder.DropIndex(
                name: "IX_Users_PondId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PondId",
                table: "Users");
        }
    }
}
