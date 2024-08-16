using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Freelancers.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ImproveSeedDataImplementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aacecacd-28e1-43cc-92da-decb1f9b32c4", "b209d16f-f471-4e70-a305-d992ab4daf29", true, "Customer", "CUSTOMER" },
                    { "ce2fd704-7a3c-4a03-846e-c5479a8b921d", "448b8f1a-b810-4c70-94cf-7b956a26d519", false, "Freelancer", "FREELANCER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "416282aa-69b8-4f2e-a5d4-6644f2884151", 0, "D54D1E8F-A9EE-408E-8C04-79830D8D8804", "freelancer@gmail.com", true, "Freelancer", "Freelancer", false, null, "FREELANCER@GMAIL.COM", "FREELANCER@GMAIL.COM", "AQAAAAIAAYagAAAAELqKOF7x2xoQTXKM0yg0kiWVKHIGCszfb4Z8c20BcALXfHoLli0jmMNSt3AUnVDbqw==", null, false, "C13DAE58-0332-4518-BB26-8ECAD93C61C5", false, "freelancer@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ce2fd704-7a3c-4a03-846e-c5479a8b921d", "416282aa-69b8-4f2e-a5d4-6644f2884151" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aacecacd-28e1-43cc-92da-decb1f9b32c4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce2fd704-7a3c-4a03-846e-c5479a8b921d", "416282aa-69b8-4f2e-a5d4-6644f2884151" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce2fd704-7a3c-4a03-846e-c5479a8b921d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "416282aa-69b8-4f2e-a5d4-6644f2884151");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "AspNetRoles");
        }
    }
}
