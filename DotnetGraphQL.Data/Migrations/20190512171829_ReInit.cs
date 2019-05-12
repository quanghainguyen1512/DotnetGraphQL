using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetGraphQL.Data.Migrations
{
    public partial class ReInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Employees_EmployeeId",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_EmployeeId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Assignments");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                columns: new[] { "EmployeeId", "TaskId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Employees_EmployeeId",
                table: "Assignments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Employees_EmployeeId",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Assignments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                columns: new[] { "EmpId", "TaskId" });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_EmployeeId",
                table: "Assignments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Employees_EmployeeId",
                table: "Assignments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
