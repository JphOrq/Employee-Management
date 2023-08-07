using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class SeedEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "Department", "Email", "FirstName", "LastName", "MiddleName", "Salary" },
                values: new object[] { 6, "B7 L8 Espina St., Caloocan City", new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "joseph_orquita@yahoo.com", "Jose", "Orqu", "Cali", 30000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}