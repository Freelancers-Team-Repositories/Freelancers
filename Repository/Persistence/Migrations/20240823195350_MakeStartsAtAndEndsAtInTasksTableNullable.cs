using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancers.Repository.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MakeStartsAtAndEndsAtInTasksTableNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartAt",
                table: "FreelancerTasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndAt",
                table: "FreelancerTasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "416282aa-69b8-4f2e-a5d4-6644f2884151",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBBU4+NzT7kUZRbyTEiijiLw18FcMMO6jDpFfDGLfipxKiA5ZU4PCUzynKNc68CCxA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartAt",
                table: "FreelancerTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndAt",
                table: "FreelancerTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "416282aa-69b8-4f2e-a5d4-6644f2884151",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOE6yy/4Tvrvk5taJSOf9+oDlRAkxuZd3zWxcI4smd5fL2vvmZx9oqufhuiMfYH/XQ==");
        }
    }
}
