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
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JoiningDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Department", "Email", "FullName", "JoiningDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 2, 6, 20, 16, 15, 838, DateTimeKind.Utc).AddTicks(4070), new DateOnly(2002, 6, 6), "Admin", "admin@timesheet.com", "Admin", new DateOnly(2025, 1, 1), new byte[] { 186, 166, 251, 220, 176, 38, 52, 32, 167, 188, 16, 220, 166, 198, 67, 199, 113, 16, 97, 39, 177, 225, 182, 78, 254, 145, 68, 214, 235, 199, 66, 121, 106, 79, 198, 182, 63, 69, 42, 74, 45, 205, 254, 39, 86, 240, 16, 179, 143, 116, 212, 199, 82, 179, 201, 207, 77, 109, 133, 144, 79, 214, 132, 137 }, new byte[] { 159, 189, 55, 186, 32, 156, 238, 249, 115, 222, 6, 237, 124, 190, 232, 200, 65, 91, 102, 140, 128, 2, 30, 112, 240, 33, 64, 222, 133, 247, 136, 144, 17, 117, 29, 16, 34, 11, 13, 84, 184, 53, 9, 120, 229, 197, 110, 106, 154, 139, 251, 104, 225, 171, 85, 180, 249, 12, 208, 144, 142, 109, 146, 67, 205, 91, 26, 90, 19, 155, 44, 8, 187, 20, 214, 38, 184, 155, 145, 32, 173, 138, 62, 75, 171, 24, 73, 45, 215, 210, 78, 57, 220, 238, 241, 45, 192, 195, 248, 244, 125, 9, 252, 18, 196, 174, 56, 159, 116, 5, 117, 172, 229, 143, 116, 85, 113, 223, 164, 88, 169, 254, 4, 29, 10, 27, 35, 125 }, "9876543456", "Admin", new DateTime(2025, 2, 6, 20, 16, 15, 838, DateTimeKind.Utc).AddTicks(4071) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
