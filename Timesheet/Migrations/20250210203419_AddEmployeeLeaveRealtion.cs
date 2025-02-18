using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeLeaveRealtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 10, 20, 34, 19, 509, DateTimeKind.Utc).AddTicks(2115), new byte[] { 74, 194, 230, 164, 76, 120, 98, 119, 66, 152, 132, 228, 176, 195, 211, 35, 35, 139, 157, 38, 169, 6, 31, 92, 39, 133, 254, 38, 190, 67, 185, 129, 196, 192, 14, 54, 224, 36, 15, 141, 170, 214, 4, 111, 227, 197, 201, 250, 18, 236, 203, 169, 255, 179, 56, 151, 123, 71, 38, 251, 77, 140, 178, 50 }, new byte[] { 157, 34, 239, 22, 165, 44, 137, 121, 8, 227, 83, 223, 226, 97, 191, 230, 183, 28, 232, 245, 142, 16, 113, 27, 149, 130, 14, 26, 15, 136, 174, 36, 195, 63, 53, 48, 228, 96, 188, 231, 200, 104, 195, 76, 105, 220, 77, 251, 13, 196, 72, 113, 65, 86, 133, 210, 120, 148, 80, 106, 181, 2, 131, 7, 141, 177, 51, 161, 87, 151, 209, 200, 238, 24, 190, 244, 250, 131, 134, 65, 119, 7, 107, 43, 243, 230, 194, 237, 25, 73, 8, 14, 63, 212, 179, 7, 4, 14, 161, 3, 52, 82, 191, 82, 242, 236, 245, 93, 126, 239, 22, 144, 66, 88, 251, 80, 139, 236, 229, 9, 57, 163, 18, 76, 23, 89, 188, 216 }, new DateTime(2025, 2, 10, 20, 34, 19, 509, DateTimeKind.Utc).AddTicks(2116) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 10, 20, 31, 27, 136, DateTimeKind.Utc).AddTicks(5514), new byte[] { 173, 166, 211, 55, 41, 73, 219, 154, 230, 97, 17, 33, 172, 110, 196, 101, 89, 75, 247, 148, 200, 23, 184, 136, 164, 99, 197, 38, 170, 61, 26, 127, 137, 238, 94, 18, 125, 39, 53, 33, 45, 66, 29, 7, 76, 243, 174, 29, 22, 191, 20, 130, 74, 122, 42, 104, 217, 71, 221, 85, 210, 182, 131, 173 }, new byte[] { 172, 169, 88, 154, 75, 85, 215, 122, 247, 162, 85, 218, 58, 176, 176, 242, 234, 228, 9, 22, 124, 25, 124, 8, 37, 120, 150, 249, 237, 239, 35, 80, 210, 74, 35, 109, 253, 70, 241, 150, 232, 3, 242, 124, 229, 89, 79, 52, 48, 136, 130, 184, 123, 41, 145, 191, 88, 97, 153, 156, 194, 150, 3, 187, 118, 21, 131, 218, 109, 89, 185, 76, 10, 82, 94, 189, 132, 226, 160, 23, 98, 245, 50, 101, 12, 184, 166, 40, 141, 76, 5, 215, 38, 27, 180, 86, 53, 188, 52, 141, 141, 219, 217, 107, 129, 97, 15, 4, 149, 146, 248, 156, 81, 52, 115, 125, 122, 87, 128, 49, 146, 161, 17, 22, 118, 139, 190, 124 }, new DateTime(2025, 2, 10, 20, 31, 27, 136, DateTimeKind.Utc).AddTicks(5515) });
        }
    }
}
