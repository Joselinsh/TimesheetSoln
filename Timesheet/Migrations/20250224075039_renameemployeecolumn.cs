using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class renameemployeecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 7, 50, 39, 265, DateTimeKind.Utc).AddTicks(5581), new byte[] { 25, 123, 53, 56, 97, 163, 56, 150, 169, 142, 238, 2, 41, 245, 57, 35, 9, 46, 191, 180, 87, 71, 112, 252, 209, 137, 158, 179, 140, 7, 145, 90, 49, 111, 226, 21, 148, 171, 115, 134, 161, 51, 62, 14, 98, 15, 149, 193, 103, 59, 79, 11, 39, 226, 169, 29, 211, 203, 39, 154, 224, 241, 218, 110 }, new byte[] { 195, 50, 149, 181, 20, 57, 237, 244, 130, 88, 242, 252, 170, 197, 100, 222, 59, 120, 70, 211, 224, 61, 155, 108, 64, 139, 130, 0, 13, 248, 75, 186, 165, 148, 205, 216, 144, 136, 195, 254, 205, 41, 226, 121, 13, 44, 228, 125, 150, 53, 93, 216, 143, 241, 28, 229, 110, 24, 116, 108, 216, 85, 93, 252, 211, 192, 226, 139, 130, 177, 177, 20, 24, 99, 134, 114, 20, 112, 229, 1, 102, 222, 112, 87, 147, 74, 170, 41, 249, 5, 160, 96, 211, 182, 246, 13, 70, 234, 54, 176, 116, 108, 210, 241, 75, 162, 105, 61, 62, 86, 136, 64, 120, 248, 81, 251, 63, 238, 18, 45, 181, 234, 230, 218, 60, 230, 215, 232 }, new DateTime(2025, 2, 24, 7, 50, 39, 265, DateTimeKind.Utc).AddTicks(5582) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 7, 10, 3, 342, DateTimeKind.Utc).AddTicks(2401), new byte[] { 88, 102, 60, 115, 63, 32, 171, 143, 46, 45, 63, 9, 128, 112, 29, 123, 236, 223, 151, 232, 182, 241, 3, 236, 105, 150, 223, 167, 54, 105, 182, 239, 215, 239, 222, 75, 34, 239, 181, 166, 227, 245, 65, 180, 0, 222, 150, 105, 13, 87, 16, 189, 57, 107, 165, 24, 82, 135, 202, 139, 179, 167, 160, 252 }, new byte[] { 68, 43, 35, 190, 80, 189, 253, 232, 42, 178, 9, 238, 104, 45, 62, 15, 135, 152, 248, 219, 121, 95, 3, 203, 77, 133, 136, 199, 97, 76, 81, 65, 10, 103, 170, 207, 107, 211, 88, 14, 160, 82, 80, 218, 77, 115, 177, 21, 159, 171, 136, 97, 163, 214, 176, 210, 10, 90, 184, 33, 133, 4, 48, 106, 15, 94, 174, 96, 2, 11, 21, 33, 203, 189, 178, 85, 244, 142, 205, 243, 37, 37, 140, 11, 62, 135, 68, 228, 165, 214, 227, 199, 100, 14, 220, 151, 255, 56, 57, 109, 199, 71, 206, 23, 189, 242, 139, 74, 105, 2, 102, 33, 254, 102, 248, 1, 150, 102, 248, 210, 243, 33, 95, 111, 162, 245, 254, 197 }, new DateTime(2025, 2, 24, 7, 10, 3, 342, DateTimeKind.Utc).AddTicks(2401) });
        }
    }
}
