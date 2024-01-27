using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradeMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddGradeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "STUDENT",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.CreateTable(
                name: "GRADE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar (50)", nullable: true),
                    Description = table.Column<string>(type: "varchar (250)", nullable: true),
                    Score = table.Column<decimal>(type: "decimal (18,0)", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRADE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GRADE_STUDENT_StudentID",
                        column: x => x.StudentID,
                        principalTable: "STUDENT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRADE_StudentID",
                table: "GRADE",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRADE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "STUDENT",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime ",
                oldNullable: true);
        }
    }
}
