using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeAndHRTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Unassigned",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 7, 5, 36, 50, 678, DateTimeKind.Utc).AddTicks(3648), new byte[] { 55, 138, 186, 23, 91, 218, 231, 36, 129, 107, 136, 185, 93, 61, 137, 56, 141, 230, 238, 117, 65, 181, 198, 247, 70, 52, 117, 74, 232, 113, 140, 239, 116, 110, 21, 88, 244, 31, 140, 13, 57, 250, 128, 14, 44, 128, 48, 155, 254, 174, 52, 19, 180, 165, 239, 252, 66, 195, 145, 238, 96, 62, 122, 107 }, new byte[] { 137, 165, 225, 207, 166, 88, 241, 95, 89, 130, 24, 139, 176, 221, 247, 45, 36, 233, 213, 39, 103, 96, 30, 32, 203, 173, 107, 138, 104, 138, 6, 132, 95, 40, 240, 69, 107, 182, 101, 209, 184, 169, 138, 170, 102, 228, 225, 69, 5, 100, 32, 116, 51, 163, 251, 162, 42, 177, 99, 200, 185, 57, 142, 117, 112, 173, 173, 196, 167, 39, 77, 180, 186, 114, 112, 1, 71, 23, 24, 230, 176, 57, 182, 179, 135, 140, 60, 188, 224, 233, 154, 101, 185, 116, 46, 198, 254, 177, 94, 232, 13, 52, 15, 139, 139, 232, 145, 164, 119, 220, 169, 177, 99, 147, 45, 47, 32, 98, 104, 137, 155, 221, 155, 94, 193, 237, 182, 172 }, new DateTime(2025, 2, 7, 5, 36, 50, 678, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HRs_UserId",
                table: "HRs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "HRs");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Unassigned");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 6, 20, 16, 15, 838, DateTimeKind.Utc).AddTicks(4070), new byte[] { 186, 166, 251, 220, 176, 38, 52, 32, 167, 188, 16, 220, 166, 198, 67, 199, 113, 16, 97, 39, 177, 225, 182, 78, 254, 145, 68, 214, 235, 199, 66, 121, 106, 79, 198, 182, 63, 69, 42, 74, 45, 205, 254, 39, 86, 240, 16, 179, 143, 116, 212, 199, 82, 179, 201, 207, 77, 109, 133, 144, 79, 214, 132, 137 }, new byte[] { 159, 189, 55, 186, 32, 156, 238, 249, 115, 222, 6, 237, 124, 190, 232, 200, 65, 91, 102, 140, 128, 2, 30, 112, 240, 33, 64, 222, 133, 247, 136, 144, 17, 117, 29, 16, 34, 11, 13, 84, 184, 53, 9, 120, 229, 197, 110, 106, 154, 139, 251, 104, 225, 171, 85, 180, 249, 12, 208, 144, 142, 109, 146, 67, 205, 91, 26, 90, 19, 155, 44, 8, 187, 20, 214, 38, 184, 155, 145, 32, 173, 138, 62, 75, 171, 24, 73, 45, 215, 210, 78, 57, 220, 238, 241, 45, 192, 195, 248, 244, 125, 9, 252, 18, 196, 174, 56, 159, 116, 5, 117, 172, 229, 143, 116, 85, 113, 223, 164, 88, 169, 254, 4, 29, 10, 27, 35, 125 }, new DateTime(2025, 2, 6, 20, 16, 15, 838, DateTimeKind.Utc).AddTicks(4071) });
        }
    }
}
