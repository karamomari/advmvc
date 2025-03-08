using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_CourseID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseID",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_CourseID",
                table: "Courses",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");
        }
    }
}
