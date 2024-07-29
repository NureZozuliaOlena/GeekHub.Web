using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekHub.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Addingnormalizedusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ace160ef-b8a8-4920-a818-8d86d42ce997",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e3a3ddd-9621-43bc-b29d-c4ae8fb46c9f", "SUPERADMIN@GEEKHUB.COM", "SUPERADMIN@GEEKHUB.COM", "AQAAAAIAAYagAAAAECVcp6Rb4GOVzROfHU920A7ZvMKMsd8zfQhs2QnalwVBhUsahxj8NeuM8/QGKl13FQ==", "f4cb9842-87b9-4422-b181-539457beb2d9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ace160ef-b8a8-4920-a818-8d86d42ce997",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e444f04f-d6cc-4308-878f-689cc4ec38aa", null, null, "AQAAAAIAAYagAAAAEAsRuucq7k77bi9rlG/CEn2AZ/wfFyKW2avXz54O7ygiZBtkJyRp3j7I1Pk8X1O6NQ==", "41ba4111-51cb-4e2b-8246-157d6b952c91" });
        }
    }
}
