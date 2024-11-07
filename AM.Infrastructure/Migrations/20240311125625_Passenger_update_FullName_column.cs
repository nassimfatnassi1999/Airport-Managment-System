using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Passenger_update_FullName_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName_lastName",
                table: "Passangers",
                newName: "PassLastName");

            migrationBuilder.RenameColumn(
                name: "FullName_firstName",
                table: "Passangers",
                newName: "PassFirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassLastName",
                table: "Passangers",
                newName: "FullName_lastName");

            migrationBuilder.RenameColumn(
                name: "PassFirstName",
                table: "Passangers",
                newName: "FullName_firstName");
        }
    }
}
