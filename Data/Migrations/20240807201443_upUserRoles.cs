using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPlace.Migrations
{
    /// <inheritdoc />
    public partial class upUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0ba69efc-63fa-485a-b203-df47d176ade9", "24b66367-f65b-4c07-9535-9b4a594c1db0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0ba69efc-63fa-485a-b203-df47d176ade9", "24b66367-f65b-4c07-9535-9b4a594c1db0" });
        }
    }
}
