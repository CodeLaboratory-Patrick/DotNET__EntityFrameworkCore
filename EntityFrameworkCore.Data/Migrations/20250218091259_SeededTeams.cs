using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Utc), "Liverpool" },
                    { 2, new DateTime(2023, 1, 1, 2, 2, 2, 0, DateTimeKind.Utc), "Arsenal" },
                    { 3, new DateTime(2023, 1, 1, 3, 3, 3, 0, DateTimeKind.Utc), "Tottenham Hotspur" },
                    { 4, new DateTime(2023, 1, 1, 4, 4, 4, 0, DateTimeKind.Utc), "Manchester City" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 4);
        }
    }
}
