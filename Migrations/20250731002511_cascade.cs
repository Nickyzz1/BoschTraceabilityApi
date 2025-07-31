using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi2.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Stations_CurStationId",
                table: "Parts");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Stations_CurStationId",
                table: "Parts",
                column: "CurStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Stations_CurStationId",
                table: "Parts");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Stations_CurStationId",
                table: "Parts",
                column: "CurStationId",
                principalTable: "Stations",
                principalColumn: "Id");
        }
    }
}
