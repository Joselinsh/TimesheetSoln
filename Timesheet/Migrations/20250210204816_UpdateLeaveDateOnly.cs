using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLeaveDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 10, 20, 48, 16, 372, DateTimeKind.Utc).AddTicks(8495), new byte[] { 60, 211, 57, 200, 10, 80, 156, 254, 58, 155, 147, 35, 232, 192, 42, 86, 27, 71, 100, 203, 131, 142, 240, 14, 164, 146, 49, 175, 116, 10, 178, 99, 189, 26, 249, 138, 145, 72, 254, 164, 174, 190, 48, 17, 18, 76, 0, 1, 57, 133, 227, 141, 214, 194, 73, 142, 176, 253, 231, 60, 174, 9, 5, 227 }, new byte[] { 160, 84, 41, 175, 0, 145, 253, 193, 87, 8, 191, 206, 48, 221, 33, 153, 41, 42, 117, 90, 253, 157, 127, 52, 164, 61, 24, 114, 3, 179, 239, 76, 76, 96, 236, 77, 72, 1, 180, 102, 64, 181, 181, 252, 93, 34, 212, 13, 195, 231, 239, 32, 26, 37, 136, 82, 84, 188, 200, 206, 247, 10, 39, 158, 46, 94, 232, 23, 249, 18, 1, 20, 68, 27, 63, 91, 43, 181, 255, 254, 125, 86, 105, 98, 144, 204, 46, 197, 197, 28, 173, 179, 33, 219, 20, 174, 156, 254, 177, 77, 200, 12, 62, 192, 237, 65, 245, 74, 16, 70, 28, 4, 83, 88, 150, 233, 158, 244, 152, 171, 134, 160, 137, 218, 10, 53, 92, 209 }, new DateTime(2025, 2, 10, 20, 48, 16, 372, DateTimeKind.Utc).AddTicks(8495) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Leaves",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Leaves",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 10, 20, 34, 19, 509, DateTimeKind.Utc).AddTicks(2115), new byte[] { 74, 194, 230, 164, 76, 120, 98, 119, 66, 152, 132, 228, 176, 195, 211, 35, 35, 139, 157, 38, 169, 6, 31, 92, 39, 133, 254, 38, 190, 67, 185, 129, 196, 192, 14, 54, 224, 36, 15, 141, 170, 214, 4, 111, 227, 197, 201, 250, 18, 236, 203, 169, 255, 179, 56, 151, 123, 71, 38, 251, 77, 140, 178, 50 }, new byte[] { 157, 34, 239, 22, 165, 44, 137, 121, 8, 227, 83, 223, 226, 97, 191, 230, 183, 28, 232, 245, 142, 16, 113, 27, 149, 130, 14, 26, 15, 136, 174, 36, 195, 63, 53, 48, 228, 96, 188, 231, 200, 104, 195, 76, 105, 220, 77, 251, 13, 196, 72, 113, 65, 86, 133, 210, 120, 148, 80, 106, 181, 2, 131, 7, 141, 177, 51, 161, 87, 151, 209, 200, 238, 24, 190, 244, 250, 131, 134, 65, 119, 7, 107, 43, 243, 230, 194, 237, 25, 73, 8, 14, 63, 212, 179, 7, 4, 14, 161, 3, 52, 82, 191, 82, 242, 236, 245, 93, 126, 239, 22, 144, 66, 88, 251, 80, 139, 236, 229, 9, 57, 163, 18, 76, 23, 89, 188, 216 }, new DateTime(2025, 2, 10, 20, 34, 19, 509, DateTimeKind.Utc).AddTicks(2116) });
        }
    }
}
