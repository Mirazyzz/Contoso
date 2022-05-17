using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contoso.Infrastructure.Migrations
{
    public partial class AddStudentDepartmentRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                table: "Student",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_DepartmentId",
                table: "Student",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_DepartmentId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_DepartmentId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Student");
        }
    }
}
