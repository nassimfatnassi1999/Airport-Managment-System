using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class useTPTheritageonAMContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTraveller",
                table: "Passangers");

            migrationBuilder.DropColumn(
                name: "employmentDate",
                table: "Passangers");

            migrationBuilder.DropColumn(
                name: "function",
                table: "Passangers");

            migrationBuilder.DropColumn(
                name: "healthInformation",
                table: "Passangers");

            migrationBuilder.DropColumn(
                name: "nationality",
                table: "Passangers");

            migrationBuilder.DropColumn(
                name: "salary",
                table: "Passangers");

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    passportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    employmentDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.passportNumber);
                    table.ForeignKey(
                        name: "FK_Staffs_Passangers_passportNumber",
                        column: x => x.passportNumber,
                        principalTable: "Passangers",
                        principalColumn: "passportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    passportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    healthInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.passportNumber);
                    table.ForeignKey(
                        name: "FK_Travellers_Passangers_passportNumber",
                        column: x => x.passportNumber,
                        principalTable: "Passangers",
                        principalColumn: "passportNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Travellers");

            migrationBuilder.AddColumn<string>(
                name: "IsTraveller",
                table: "Passangers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "employmentDate",
                table: "Passangers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "function",
                table: "Passangers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "healthInformation",
                table: "Passangers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nationality",
                table: "Passangers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "salary",
                table: "Passangers",
                type: "float",
                nullable: true);
        }
    }
}
