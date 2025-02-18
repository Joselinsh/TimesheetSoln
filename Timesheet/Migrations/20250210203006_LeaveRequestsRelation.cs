using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class LeaveRequestsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Pending")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_Employees_EmployeeId",
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
                values: new object[] { new DateTime(2025, 2, 10, 20, 30, 6, 232, DateTimeKind.Utc).AddTicks(9487), new byte[] { 49, 189, 214, 173, 202, 157, 63, 83, 196, 93, 96, 102, 123, 72, 96, 73, 10, 15, 200, 49, 249, 117, 57, 22, 29, 161, 168, 187, 13, 157, 114, 168, 237, 125, 69, 163, 174, 229, 112, 68, 79, 51, 164, 111, 150, 192, 168, 65, 180, 103, 43, 60, 241, 89, 39, 118, 88, 248, 126, 48, 80, 253, 253, 36 }, new byte[] { 100, 89, 235, 241, 152, 34, 164, 19, 109, 27, 187, 10, 133, 179, 55, 33, 246, 114, 62, 134, 66, 97, 1, 50, 132, 86, 229, 132, 203, 94, 80, 111, 200, 248, 78, 11, 48, 222, 69, 251, 241, 241, 206, 78, 15, 102, 229, 195, 193, 210, 207, 148, 180, 99, 145, 210, 157, 231, 135, 34, 2, 202, 58, 36, 22, 41, 86, 160, 251, 179, 223, 96, 88, 41, 107, 229, 168, 66, 220, 101, 118, 95, 195, 204, 195, 142, 87, 167, 128, 140, 8, 8, 139, 171, 218, 31, 71, 145, 231, 122, 22, 245, 246, 81, 161, 170, 139, 187, 140, 220, 150, 226, 40, 217, 227, 115, 68, 142, 48, 99, 226, 227, 117, 94, 147, 48, 219, 25 }, new DateTime(2025, 2, 10, 20, 30, 6, 232, DateTimeKind.Utc).AddTicks(9488) });

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_EmployeeId",
                table: "Leaves",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 10, 16, 48, 31, 415, DateTimeKind.Utc).AddTicks(9471), new byte[] { 193, 99, 242, 247, 201, 61, 229, 68, 144, 112, 89, 178, 42, 160, 229, 67, 6, 209, 233, 41, 8, 134, 28, 163, 41, 124, 106, 205, 224, 197, 242, 217, 158, 237, 193, 62, 127, 254, 23, 221, 162, 86, 77, 184, 170, 45, 153, 173, 58, 125, 69, 162, 197, 14, 80, 83, 10, 177, 21, 137, 82, 131, 3, 91 }, new byte[] { 217, 54, 121, 205, 66, 96, 135, 236, 240, 148, 125, 221, 59, 237, 214, 27, 88, 175, 130, 218, 154, 114, 137, 142, 165, 48, 254, 20, 81, 51, 184, 85, 172, 91, 66, 232, 119, 5, 64, 142, 131, 171, 67, 227, 99, 123, 11, 85, 229, 193, 1, 4, 92, 142, 122, 207, 238, 5, 181, 207, 232, 31, 101, 225, 152, 71, 191, 130, 49, 34, 81, 224, 70, 242, 82, 53, 47, 225, 165, 57, 59, 127, 7, 69, 222, 254, 97, 54, 215, 210, 191, 165, 38, 213, 198, 195, 183, 251, 238, 206, 85, 114, 83, 84, 122, 94, 235, 240, 186, 4, 219, 164, 176, 240, 92, 13, 4, 67, 129, 64, 121, 76, 42, 136, 135, 19, 195, 112 }, new DateTime(2025, 2, 10, 16, 48, 31, 415, DateTimeKind.Utc).AddTicks(9472) });
        }
    }
}
