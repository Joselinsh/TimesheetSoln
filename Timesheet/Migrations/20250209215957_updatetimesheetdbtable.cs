using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class updatetimesheetdbtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Timesheets");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 59, 57, 19, DateTimeKind.Utc).AddTicks(8448), new byte[] { 81, 19, 184, 214, 52, 85, 121, 248, 86, 17, 216, 217, 99, 131, 7, 119, 162, 44, 100, 39, 51, 59, 166, 186, 72, 62, 128, 126, 82, 135, 83, 239, 209, 29, 92, 223, 61, 209, 67, 104, 182, 50, 62, 201, 242, 72, 5, 158, 34, 191, 197, 27, 7, 100, 69, 116, 152, 17, 217, 170, 209, 97, 246, 207 }, new byte[] { 155, 29, 92, 244, 27, 44, 79, 30, 198, 239, 106, 21, 6, 208, 44, 230, 133, 127, 213, 158, 21, 21, 121, 208, 9, 211, 234, 160, 10, 183, 5, 114, 123, 30, 150, 46, 27, 2, 26, 51, 255, 218, 113, 37, 190, 109, 63, 158, 5, 221, 195, 62, 180, 52, 139, 74, 2, 140, 87, 254, 249, 67, 241, 61, 89, 212, 105, 239, 167, 58, 200, 143, 2, 30, 90, 100, 147, 39, 214, 201, 29, 11, 153, 134, 101, 167, 59, 182, 0, 233, 119, 205, 114, 10, 255, 209, 67, 67, 79, 227, 158, 115, 116, 61, 184, 174, 70, 93, 185, 121, 162, 137, 59, 18, 67, 126, 4, 161, 242, 118, 39, 126, 238, 221, 130, 228, 130, 164 }, new DateTime(2025, 2, 9, 21, 59, 57, 19, DateTimeKind.Utc).AddTicks(8449) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Timesheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 20, 54, 301, DateTimeKind.Utc).AddTicks(3934), new byte[] { 46, 173, 239, 100, 164, 66, 249, 194, 107, 12, 18, 64, 164, 36, 159, 181, 134, 191, 166, 41, 226, 206, 10, 88, 44, 113, 97, 56, 182, 34, 67, 167, 61, 26, 5, 255, 142, 131, 163, 196, 236, 176, 251, 48, 136, 249, 86, 44, 187, 86, 248, 20, 28, 191, 5, 109, 127, 154, 159, 19, 206, 176, 248, 238 }, new byte[] { 131, 113, 28, 140, 168, 185, 126, 90, 207, 181, 107, 64, 122, 13, 200, 51, 136, 8, 152, 15, 138, 232, 43, 148, 222, 192, 60, 68, 202, 200, 1, 125, 201, 167, 131, 170, 249, 47, 202, 52, 102, 24, 241, 246, 111, 83, 10, 130, 248, 230, 129, 25, 184, 240, 189, 144, 15, 243, 86, 231, 169, 187, 2, 108, 192, 98, 69, 93, 69, 161, 213, 103, 71, 246, 96, 242, 174, 38, 28, 38, 210, 45, 181, 203, 151, 74, 120, 220, 152, 228, 94, 105, 236, 39, 32, 137, 134, 111, 191, 132, 95, 128, 39, 241, 160, 166, 9, 163, 3, 190, 66, 55, 125, 37, 156, 190, 233, 158, 153, 212, 99, 186, 132, 223, 142, 165, 89, 119 }, new DateTime(2025, 2, 9, 21, 20, 54, 301, DateTimeKind.Utc).AddTicks(3935) });
        }
    }
}
