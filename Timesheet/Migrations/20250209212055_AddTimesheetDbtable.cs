using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class AddTimesheetDbtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    HoursWorked = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 20, 54, 301, DateTimeKind.Utc).AddTicks(3934), new byte[] { 46, 173, 239, 100, 164, 66, 249, 194, 107, 12, 18, 64, 164, 36, 159, 181, 134, 191, 166, 41, 226, 206, 10, 88, 44, 113, 97, 56, 182, 34, 67, 167, 61, 26, 5, 255, 142, 131, 163, 196, 236, 176, 251, 48, 136, 249, 86, 44, 187, 86, 248, 20, 28, 191, 5, 109, 127, 154, 159, 19, 206, 176, 248, 238 }, new byte[] { 131, 113, 28, 140, 168, 185, 126, 90, 207, 181, 107, 64, 122, 13, 200, 51, 136, 8, 152, 15, 138, 232, 43, 148, 222, 192, 60, 68, 202, 200, 1, 125, 201, 167, 131, 170, 249, 47, 202, 52, 102, 24, 241, 246, 111, 83, 10, 130, 248, 230, 129, 25, 184, 240, 189, 144, 15, 243, 86, 231, 169, 187, 2, 108, 192, 98, 69, 93, 69, 161, 213, 103, 71, 246, 96, 242, 174, 38, 28, 38, 210, 45, 181, 203, 151, 74, 120, 220, 152, 228, 94, 105, 236, 39, 32, 137, 134, 111, 191, 132, 95, 128, 39, 241, 160, 166, 9, 163, 3, 190, 66, 55, 125, 37, 156, 190, 233, 158, 153, 212, 99, 186, 132, 223, 142, 165, 89, 119 }, new DateTime(2025, 2, 9, 21, 20, 54, 301, DateTimeKind.Utc).AddTicks(3935) });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_EmployeeId",
                table: "Timesheets",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 15, 14, 0, 493, DateTimeKind.Utc).AddTicks(6115), new byte[] { 50, 179, 205, 150, 0, 244, 118, 112, 101, 68, 34, 178, 30, 238, 177, 181, 73, 167, 159, 45, 114, 120, 88, 46, 221, 187, 6, 81, 52, 252, 83, 54, 252, 170, 121, 222, 45, 231, 251, 63, 211, 141, 108, 144, 228, 47, 141, 144, 174, 183, 43, 65, 168, 138, 135, 111, 101, 246, 83, 63, 28, 202, 192, 27 }, new byte[] { 73, 69, 64, 88, 43, 170, 45, 234, 45, 139, 117, 160, 200, 49, 194, 189, 157, 61, 186, 127, 130, 132, 247, 152, 188, 132, 154, 158, 216, 207, 141, 11, 179, 239, 140, 205, 47, 228, 34, 1, 72, 209, 160, 156, 32, 143, 63, 1, 20, 223, 217, 201, 79, 128, 12, 214, 163, 5, 29, 161, 43, 127, 182, 185, 151, 55, 150, 203, 211, 31, 56, 244, 249, 205, 136, 122, 28, 133, 5, 59, 219, 165, 79, 132, 0, 230, 19, 68, 123, 246, 77, 70, 162, 18, 27, 180, 98, 16, 155, 130, 46, 87, 156, 141, 140, 120, 5, 133, 122, 231, 98, 212, 24, 247, 180, 30, 67, 230, 52, 12, 121, 127, 220, 147, 249, 1, 28, 41 }, new DateTime(2025, 2, 9, 15, 14, 0, 493, DateTimeKind.Utc).AddTicks(6116) });
        }
    }
}
