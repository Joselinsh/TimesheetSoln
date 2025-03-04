using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class renametimesheetcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Timesheets",
                newName: "TimesheetId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 7, 10, 3, 342, DateTimeKind.Utc).AddTicks(2401), new byte[] { 88, 102, 60, 115, 63, 32, 171, 143, 46, 45, 63, 9, 128, 112, 29, 123, 236, 223, 151, 232, 182, 241, 3, 236, 105, 150, 223, 167, 54, 105, 182, 239, 215, 239, 222, 75, 34, 239, 181, 166, 227, 245, 65, 180, 0, 222, 150, 105, 13, 87, 16, 189, 57, 107, 165, 24, 82, 135, 202, 139, 179, 167, 160, 252 }, new byte[] { 68, 43, 35, 190, 80, 189, 253, 232, 42, 178, 9, 238, 104, 45, 62, 15, 135, 152, 248, 219, 121, 95, 3, 203, 77, 133, 136, 199, 97, 76, 81, 65, 10, 103, 170, 207, 107, 211, 88, 14, 160, 82, 80, 218, 77, 115, 177, 21, 159, 171, 136, 97, 163, 214, 176, 210, 10, 90, 184, 33, 133, 4, 48, 106, 15, 94, 174, 96, 2, 11, 21, 33, 203, 189, 178, 85, 244, 142, 205, 243, 37, 37, 140, 11, 62, 135, 68, 228, 165, 214, 227, 199, 100, 14, 220, 151, 255, 56, 57, 109, 199, 71, 206, 23, 189, 242, 139, 74, 105, 2, 102, 33, 254, 102, 248, 1, 150, 102, 248, 210, 243, 33, 95, 111, 162, 245, 254, 197 }, new DateTime(2025, 2, 24, 7, 10, 3, 342, DateTimeKind.Utc).AddTicks(2401) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimesheetId",
                table: "Timesheets",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 6, 50, 16, 475, DateTimeKind.Utc).AddTicks(2940), new byte[] { 181, 107, 228, 144, 1, 252, 25, 215, 122, 207, 95, 13, 146, 181, 142, 143, 58, 167, 91, 34, 131, 140, 3, 34, 73, 170, 77, 141, 211, 70, 228, 165, 66, 157, 166, 82, 29, 155, 20, 18, 223, 134, 67, 255, 145, 200, 55, 20, 137, 167, 81, 86, 24, 57, 105, 130, 178, 159, 231, 178, 130, 102, 31, 149 }, new byte[] { 18, 86, 149, 255, 25, 191, 176, 119, 205, 61, 159, 149, 122, 22, 139, 156, 173, 186, 91, 64, 194, 195, 226, 151, 242, 47, 148, 43, 245, 136, 79, 60, 209, 222, 162, 57, 163, 153, 93, 131, 205, 183, 121, 253, 13, 35, 229, 197, 105, 123, 51, 83, 59, 83, 122, 254, 170, 148, 52, 163, 54, 11, 22, 93, 231, 24, 112, 211, 206, 4, 114, 67, 107, 188, 242, 179, 239, 52, 57, 124, 115, 188, 132, 243, 252, 194, 141, 64, 199, 106, 71, 204, 176, 125, 164, 251, 40, 126, 101, 139, 235, 222, 131, 81, 113, 245, 8, 80, 16, 64, 86, 12, 79, 38, 147, 187, 45, 225, 53, 214, 190, 254, 21, 170, 27, 249, 214, 215 }, new DateTime(2025, 2, 24, 6, 50, 16, 475, DateTimeKind.Utc).AddTicks(2941) });
        }
    }
}
