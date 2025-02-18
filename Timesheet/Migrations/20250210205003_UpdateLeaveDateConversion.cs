using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLeaveDateConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 10, 20, 50, 3, 85, DateTimeKind.Utc).AddTicks(9442), new byte[] { 135, 188, 224, 62, 22, 217, 192, 236, 112, 130, 86, 206, 20, 10, 85, 33, 212, 54, 79, 255, 175, 231, 190, 54, 226, 123, 236, 180, 63, 193, 117, 239, 212, 50, 41, 226, 159, 200, 21, 161, 111, 175, 48, 23, 36, 195, 95, 6, 71, 141, 166, 213, 177, 135, 47, 127, 6, 55, 24, 39, 15, 252, 108, 100 }, new byte[] { 66, 98, 153, 77, 41, 179, 253, 27, 209, 0, 42, 58, 112, 118, 144, 32, 213, 231, 56, 26, 142, 39, 118, 143, 37, 109, 203, 166, 171, 40, 76, 16, 127, 141, 84, 125, 240, 94, 152, 155, 235, 124, 80, 66, 86, 220, 176, 142, 199, 143, 106, 218, 85, 172, 71, 231, 85, 153, 166, 115, 240, 82, 146, 167, 235, 46, 108, 90, 192, 157, 126, 176, 15, 90, 12, 159, 0, 225, 227, 61, 95, 28, 162, 25, 154, 72, 212, 75, 250, 214, 43, 96, 70, 104, 33, 74, 134, 127, 48, 203, 50, 99, 108, 38, 245, 48, 140, 190, 246, 220, 120, 139, 204, 22, 168, 19, 246, 175, 120, 110, 99, 106, 101, 31, 10, 246, 23, 217 }, new DateTime(2025, 2, 10, 20, 50, 3, 85, DateTimeKind.Utc).AddTicks(9442) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 10, 20, 48, 16, 372, DateTimeKind.Utc).AddTicks(8495), new byte[] { 60, 211, 57, 200, 10, 80, 156, 254, 58, 155, 147, 35, 232, 192, 42, 86, 27, 71, 100, 203, 131, 142, 240, 14, 164, 146, 49, 175, 116, 10, 178, 99, 189, 26, 249, 138, 145, 72, 254, 164, 174, 190, 48, 17, 18, 76, 0, 1, 57, 133, 227, 141, 214, 194, 73, 142, 176, 253, 231, 60, 174, 9, 5, 227 }, new byte[] { 160, 84, 41, 175, 0, 145, 253, 193, 87, 8, 191, 206, 48, 221, 33, 153, 41, 42, 117, 90, 253, 157, 127, 52, 164, 61, 24, 114, 3, 179, 239, 76, 76, 96, 236, 77, 72, 1, 180, 102, 64, 181, 181, 252, 93, 34, 212, 13, 195, 231, 239, 32, 26, 37, 136, 82, 84, 188, 200, 206, 247, 10, 39, 158, 46, 94, 232, 23, 249, 18, 1, 20, 68, 27, 63, 91, 43, 181, 255, 254, 125, 86, 105, 98, 144, 204, 46, 197, 197, 28, 173, 179, 33, 219, 20, 174, 156, 254, 177, 77, 200, 12, 62, 192, 237, 65, 245, 74, 16, 70, 28, 4, 83, 88, 150, 233, 158, 244, 152, 171, 134, 160, 137, 218, 10, 53, 92, 209 }, new DateTime(2025, 2, 10, 20, 48, 16, 372, DateTimeKind.Utc).AddTicks(8495) });
        }
    }
}
