using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekHub.Web.Migrations
{
    /// <inheritdoc />
    public partial class Fixedanerrorinthefieldname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsertId",
                table: "BlogPostComment",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BlogPostComment",
                newName: "UsertId");
        }
    }
}
