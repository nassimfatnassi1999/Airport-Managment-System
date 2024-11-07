using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class conf_with_FluentAPI_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Flights_flightsflightId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passangers_passengerspassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "FlightPassenger",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassenger_passengerspassportNumber",
                table: "Reservations",
                newName: "IX_Reservations_passengerspassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                columns: new[] { "flightsflightId", "passengerspassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Flights_flightsflightId",
                table: "Reservations",
                column: "flightsflightId",
                principalTable: "Flights",
                principalColumn: "flightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Passangers_passengerspassportNumber",
                table: "Reservations",
                column: "passengerspassportNumber",
                principalTable: "Passangers",
                principalColumn: "passportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Flights_flightsflightId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Passangers_passengerspassportNumber",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "FlightPassenger");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_passengerspassportNumber",
                table: "FlightPassenger",
                newName: "IX_FlightPassenger_passengerspassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "flightsflightId", "passengerspassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Flights_flightsflightId",
                table: "FlightPassenger",
                column: "flightsflightId",
                principalTable: "Flights",
                principalColumn: "flightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passangers_passengerspassportNumber",
                table: "FlightPassenger",
                column: "passengerspassportNumber",
                principalTable: "Passangers",
                principalColumn: "passportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
