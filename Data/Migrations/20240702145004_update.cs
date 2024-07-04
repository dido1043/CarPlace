using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPlace.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarFeatures_CarId",
                table: "CarFeatures",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeatures_Cars_CarId",
                table: "CarFeatures",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarFeatures_Cars_CarId",
                table: "CarFeatures");

            migrationBuilder.DropIndex(
                name: "IX_CarFeatures_CarId",
                table: "CarFeatures");
        }
    }
}
