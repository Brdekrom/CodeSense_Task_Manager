using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_ClientCompanies_ClientCompanyId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ClientCompanies_ClientCompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ClientCompanies_ClientCompanyId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ClientCompanies_ClientCompanyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ClientCompanies");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryEmails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryPhoneNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Companies_ClientCompanyId",
                table: "Address",
                column: "ClientCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_ClientCompanyId",
                table: "Employees",
                column: "ClientCompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Companies_ClientCompanyId",
                table: "Projects",
                column: "ClientCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_ClientCompanyId",
                table: "Users",
                column: "ClientCompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Companies_ClientCompanyId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_ClientCompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Companies_ClientCompanyId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_ClientCompanyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.CreateTable(
                name: "ClientCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryEmails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryPhoneNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCompanies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ClientCompanies_ClientCompanyId",
                table: "Address",
                column: "ClientCompanyId",
                principalTable: "ClientCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ClientCompanies_ClientCompanyId",
                table: "Employees",
                column: "ClientCompanyId",
                principalTable: "ClientCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ClientCompanies_ClientCompanyId",
                table: "Projects",
                column: "ClientCompanyId",
                principalTable: "ClientCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ClientCompanies_ClientCompanyId",
                table: "Users",
                column: "ClientCompanyId",
                principalTable: "ClientCompanies",
                principalColumn: "Id");
        }
    }
}
