using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tableproteuse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    FlightFK = table.Column<int>(type: "int", nullable: false),
                    PassengerFK = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    Siege = table.Column<int>(type: "int", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.PassengerFK, x.FlightFK });
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_FlightFK",
                        column: x => x.FlightFK,
                        principalTable: "Flights",
                        principalColumn: "flightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Passangers_PassengerFK",
                        column: x => x.PassengerFK,
                        principalTable: "Passangers",
                        principalColumn: "passportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightFK",
                table: "Ticket",
                column: "FlightFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    flightsflightId = table.Column<int>(type: "int", nullable: false),
                    passengerspassportNumber = table.Column<string>(type: "nvarchar(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.flightsflightId, x.passengerspassportNumber });
                    table.ForeignKey(
                        name: "FK_Reservations_Flights_flightsflightId",
                        column: x => x.flightsflightId,
                        principalTable: "Flights",
                        principalColumn: "flightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Passangers_passengerspassportNumber",
                        column: x => x.passengerspassportNumber,
                        principalTable: "Passangers",
                        principalColumn: "passportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_passengerspassportNumber",
                table: "Reservations",
                column: "passengerspassportNumber");
        }
    }
}
