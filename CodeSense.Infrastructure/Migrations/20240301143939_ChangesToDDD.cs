using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToDDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requirement",
                table: "Requirement");

            migrationBuilder.DropIndex(
                name: "IX_Requirement_ProjectId",
                table: "Requirement");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Requirement");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Requirement");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Requirement");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Requirement");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "RequiredEmployees",
                table: "Requirement",
                newName: "RequiredEmployees_Quantity");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Projects",
                newName: "FinancialData_Cost");

            migrationBuilder.RenameColumn(
                name: "Budget",
                table: "Projects",
                newName: "FinancialData_Budget");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Deadline",
                table: "Projects",
                newName: "ProjectDates_StartDate");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "AvailableUntil",
                table: "Employees",
                newName: "Availability_Until");

            migrationBuilder.RenameColumn(
                name: "AvailableFrom",
                table: "Employees",
                newName: "Availability_From");

            migrationBuilder.RenameColumn(
                name: "SecondaryPhoneNumbers",
                table: "Companies",
                newName: "ContactData_SecondaryPhoneNumbers");

            migrationBuilder.RenameColumn(
                name: "SecondaryEmails",
                table: "Companies",
                newName: "ContactData_SecondaryEmails");

            migrationBuilder.RenameColumn(
                name: "PrimaryPhoneNumber",
                table: "Companies",
                newName: "ContactData_PrimaryPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PrimaryEmail",
                table: "Companies",
                newName: "ContactData_PrimaryEmail");

            migrationBuilder.AddColumn<int>(
                name: "RequiredEmployees_Level",
                table: "Requirement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FinancialData_Cost",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FinancialData_Budget",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConsultancyId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ProjectDates_EndDate",
                table: "Projects",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<Guid>(
                name: "QuoteId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ContactData_PrimaryEmail",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactData_PrimaryPhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactData_SecondaryEmails",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactData_SecondaryPhoneNumbers",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployerCompanyId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinancialData_DailyRate",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinancialData_DailySalary",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinancialData_Budget",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinancialData_Cost",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClient",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MainAddressId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MainAddress_Box",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainAddress_City",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MainAddress_Country",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MainAddress_HouseNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "MainAddress_IsPrimary",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MainAddress_State",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainAddress_Street",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainAddress_ZipCode",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VATNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requirement",
                table: "Requirement",
                columns: new[] { "ProjectId", "Id" });

            migrationBuilder.CreateTable(
                name: "Companies_Addresses",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Box = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_Addresses", x => new { x.CompanyId, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectQuote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultancyId = table.Column<int>(type: "int", nullable: false),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectQuote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectQuote_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployerCompanyId",
                table: "Employees",
                column: "EmployerCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectQuote_CompanyId",
                table: "ProjectQuote",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_EmployerCompanyId",
                table: "Employees",
                column: "EmployerCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_EmployerCompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Companies_Addresses");

            migrationBuilder.DropTable(
                name: "ProjectQuote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requirement",
                table: "Requirement");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployerCompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RequiredEmployees_Level",
                table: "Requirement");

            migrationBuilder.DropColumn(
                name: "ConsultancyId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectDates_EndDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ContactData_PrimaryEmail",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContactData_PrimaryPhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContactData_SecondaryEmails",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContactData_SecondaryPhoneNumbers",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployerCompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FinancialData_DailyRate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FinancialData_DailySalary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FinancialData_Budget",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FinancialData_Cost",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsClient",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainAddressId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainAddress_Box",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainAddress_City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainAddress_Country",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainAddress_HouseNumber",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainAddress_IsPrimary",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainAddress_State",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainAddress_Street",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainAddress_ZipCode",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "VATNumber",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "RequiredEmployees_Quantity",
                table: "Requirement",
                newName: "RequiredEmployees");

            migrationBuilder.RenameColumn(
                name: "FinancialData_Cost",
                table: "Projects",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "FinancialData_Budget",
                table: "Projects",
                newName: "Budget");

            migrationBuilder.RenameColumn(
                name: "ProjectDates_StartDate",
                table: "Projects",
                newName: "Deadline");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Employees",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "Availability_Until",
                table: "Employees",
                newName: "AvailableUntil");

            migrationBuilder.RenameColumn(
                name: "Availability_From",
                table: "Employees",
                newName: "AvailableFrom");

            migrationBuilder.RenameColumn(
                name: "ContactData_SecondaryPhoneNumbers",
                table: "Companies",
                newName: "SecondaryPhoneNumbers");

            migrationBuilder.RenameColumn(
                name: "ContactData_SecondaryEmails",
                table: "Companies",
                newName: "SecondaryEmails");

            migrationBuilder.RenameColumn(
                name: "ContactData_PrimaryPhoneNumber",
                table: "Companies",
                newName: "PrimaryPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ContactData_PrimaryEmail",
                table: "Companies",
                newName: "PrimaryEmail");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Requirement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Requirement",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Requirement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Requirement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Budget",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requirement",
                table: "Requirement",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Companies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_ProjectId",
                table: "Requirement",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientCompanyId",
                table: "Address",
                column: "ClientCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
