using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class FixEmployeeTimesheetsNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Timesheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Pending",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 10, 16, 46, 45, 250, DateTimeKind.Utc).AddTicks(6877), new byte[] { 18, 87, 14, 22, 247, 21, 131, 43, 75, 38, 56, 217, 104, 252, 21, 174, 150, 181, 76, 55, 247, 188, 121, 167, 104, 56, 133, 29, 225, 69, 33, 143, 97, 46, 5, 194, 226, 126, 162, 251, 55, 242, 44, 205, 72, 63, 133, 11, 176, 175, 161, 55, 201, 246, 89, 163, 69, 86, 249, 162, 216, 152, 212, 149 }, new byte[] { 70, 153, 106, 14, 163, 171, 109, 192, 63, 113, 201, 20, 163, 43, 182, 114, 94, 165, 40, 60, 215, 180, 205, 24, 181, 93, 46, 31, 232, 43, 109, 149, 154, 254, 228, 131, 7, 107, 182, 84, 141, 35, 248, 171, 48, 66, 233, 218, 228, 110, 144, 140, 246, 46, 106, 153, 133, 237, 148, 132, 123, 105, 160, 7, 97, 129, 177, 113, 77, 82, 66, 81, 97, 86, 89, 184, 226, 222, 172, 15, 125, 232, 168, 68, 22, 226, 114, 75, 196, 149, 3, 149, 119, 136, 104, 204, 37, 26, 169, 55, 199, 19, 255, 175, 219, 71, 200, 202, 84, 168, 85, 254, 29, 110, 209, 215, 73, 137, 72, 162, 34, 9, 187, 32, 113, 219, 222, 75 }, new DateTime(2025, 2, 10, 16, 46, 45, 250, DateTimeKind.Utc).AddTicks(6878) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Pending");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 59, 57, 19, DateTimeKind.Utc).AddTicks(8448), new byte[] { 81, 19, 184, 214, 52, 85, 121, 248, 86, 17, 216, 217, 99, 131, 7, 119, 162, 44, 100, 39, 51, 59, 166, 186, 72, 62, 128, 126, 82, 135, 83, 239, 209, 29, 92, 223, 61, 209, 67, 104, 182, 50, 62, 201, 242, 72, 5, 158, 34, 191, 197, 27, 7, 100, 69, 116, 152, 17, 217, 170, 209, 97, 246, 207 }, new byte[] { 155, 29, 92, 244, 27, 44, 79, 30, 198, 239, 106, 21, 6, 208, 44, 230, 133, 127, 213, 158, 21, 21, 121, 208, 9, 211, 234, 160, 10, 183, 5, 114, 123, 30, 150, 46, 27, 2, 26, 51, 255, 218, 113, 37, 190, 109, 63, 158, 5, 221, 195, 62, 180, 52, 139, 74, 2, 140, 87, 254, 249, 67, 241, 61, 89, 212, 105, 239, 167, 58, 200, 143, 2, 30, 90, 100, 147, 39, 214, 201, 29, 11, 153, 134, 101, 167, 59, 182, 0, 233, 119, 205, 114, 10, 255, 209, 67, 67, 79, 227, 158, 115, 116, 61, 184, 174, 70, 93, 185, 121, 162, 137, 59, 18, 67, 126, 4, 161, 242, 118, 39, 126, 238, 221, 130, 228, 130, 164 }, new DateTime(2025, 2, 9, 21, 59, 57, 19, DateTimeKind.Utc).AddTicks(8449) });
        }
    }
}
