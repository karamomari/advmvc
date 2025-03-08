using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvProject.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructores_Courses_courseID",
                table: "Instructores");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructores_Departments_departmentId",
                table: "Instructores");

            migrationBuilder.DropIndex(
                name: "IX_Instructores_courseID",
                table: "Instructores");

            migrationBuilder.DropIndex(
                name: "IX_Instructores_departmentId",
                table: "Instructores");

            migrationBuilder.DropColumn(
                name: "courseID",
                table: "Instructores");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "Instructores");

            migrationBuilder.CreateIndex(
                name: "IX_Instructores_crs_id",
                table: "Instructores",
                column: "crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructores_dept_id",
                table: "Instructores",
                column: "dept_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructores_Courses_crs_id",
                table: "Instructores",
                column: "crs_id",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructores_Departments_dept_id",
                table: "Instructores",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructores_Courses_crs_id",
                table: "Instructores");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructores_Departments_dept_id",
                table: "Instructores");

            migrationBuilder.DropIndex(
                name: "IX_Instructores_crs_id",
                table: "Instructores");

            migrationBuilder.DropIndex(
                name: "IX_Instructores_dept_id",
                table: "Instructores");

            migrationBuilder.AddColumn<int>(
                name: "courseID",
                table: "Instructores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "Instructores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Instructores_courseID",
                table: "Instructores",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructores_departmentId",
                table: "Instructores",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructores_Courses_courseID",
                table: "Instructores",
                column: "courseID",
                principalTable: "Courses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructores_Departments_departmentId",
                table: "Instructores",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
