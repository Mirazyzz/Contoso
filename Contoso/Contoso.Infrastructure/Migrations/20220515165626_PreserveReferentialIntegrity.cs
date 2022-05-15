using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contoso.Infrastructure.Migrations
{
    public partial class PreserveReferentialIntegrity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_City_CityId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Department_DepartmentId",
                table: "Instructor");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_City_CityId",
                table: "Department",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Department_DepartmentId",
                table: "Instructor",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_City_CityId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Department_DepartmentId",
                table: "Instructor");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_City_CityId",
                table: "Department",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Department_DepartmentId",
                table: "Instructor",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
