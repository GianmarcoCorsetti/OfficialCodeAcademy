using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyEfPersistance.Migrations
{
    public partial class AddedEnrollmentIndexAndCourseCreationColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Courses",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId_CourseEditionId",
                table: "Enrollments",
                columns: new[] { "StudentId", "CourseEditionId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollments_StudentId_CourseEditionId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }
    }
}
