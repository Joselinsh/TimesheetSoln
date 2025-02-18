using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet.Migrations
{
    /// <inheritdoc />
    public partial class dbTimesheetApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Unassigned"),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JoiningDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Department", "Designation", "Email", "FullName", "JoiningDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 2, 9, 15, 14, 0, 493, DateTimeKind.Utc).AddTicks(6115), new DateOnly(2002, 6, 6), "Admin", "Admin", "admin@timesheet.com", "Admin", new DateOnly(2025, 1, 1), new byte[] { 50, 179, 205, 150, 0, 244, 118, 112, 101, 68, 34, 178, 30, 238, 177, 181, 73, 167, 159, 45, 114, 120, 88, 46, 221, 187, 6, 81, 52, 252, 83, 54, 252, 170, 121, 222, 45, 231, 251, 63, 211, 141, 108, 144, 228, 47, 141, 144, 174, 183, 43, 65, 168, 138, 135, 111, 101, 246, 83, 63, 28, 202, 192, 27 }, new byte[] { 73, 69, 64, 88, 43, 170, 45, 234, 45, 139, 117, 160, 200, 49, 194, 189, 157, 61, 186, 127, 130, 132, 247, 152, 188, 132, 154, 158, 216, 207, 141, 11, 179, 239, 140, 205, 47, 228, 34, 1, 72, 209, 160, 156, 32, 143, 63, 1, 20, 223, 217, 201, 79, 128, 12, 214, 163, 5, 29, 161, 43, 127, 182, 185, 151, 55, 150, 203, 211, 31, 56, 244, 249, 205, 136, 122, 28, 133, 5, 59, 219, 165, 79, 132, 0, 230, 19, 68, 123, 246, 77, 70, 162, 18, 27, 180, 98, 16, 155, 130, 46, 87, 156, 141, 140, 120, 5, 133, 122, 231, 98, 212, 24, 247, 180, 30, 67, 230, 52, 12, 121, 127, 220, 147, 249, 1, 28, 41 }, "9876543456", "Admin", new DateTime(2025, 2, 9, 15, 14, 0, 493, DateTimeKind.Utc).AddTicks(6116) });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HRs_UserId",
                table: "HRs",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "HRs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
