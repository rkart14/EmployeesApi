using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesApi.Migrations
{
    public partial class uniqueFieldForEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers1_CountryCodeId",
                table: "PhoneNumbers1");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "PhoneNumbers1",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNumber",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers1_CountryCodeId_Number",
                table: "PhoneNumbers1",
                columns: new[] { "CountryCodeId", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonalNumber",
                table: "Employees",
                column: "PersonalNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers1_CountryCodeId_Number",
                table: "PhoneNumbers1");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PersonalNumber",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "PhoneNumbers1",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNumber",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers1_CountryCodeId",
                table: "PhoneNumbers1",
                column: "CountryCodeId");
        }
    }
}
