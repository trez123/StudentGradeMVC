using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradeMVC.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COURSE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar (50)", nullable: false),
                    Description = table.Column<string>(type: "varchar (250)", nullable: true),
                    MaxStudent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar (50)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Addressln1 = table.Column<string>(type: "varchar (250)", nullable: false),
                    Addressln2 = table.Column<string>(type: "varchar (250)", nullable: false),
                    Phone = table.Column<string>(type: "varchar (11)", nullable: true),
                    Email = table.Column<string>(type: "varchar (250)", nullable: false),
                    TikTokTag = table.Column<string>(type: "varchar (50)", nullable: true),
                    IGTag = table.Column<string>(type: "varchar (50)", nullable: true),
                    StudentImage = table.Column<string>(type: "varchar (MAX)", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STUDENT_COURSE_CourseID",
                        column: x => x.CourseID,
                        principalTable: "COURSE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_CourseID",
                table: "STUDENT",
                column: "CourseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STUDENT");

            migrationBuilder.DropTable(
                name: "COURSE");
        }
    }
}
