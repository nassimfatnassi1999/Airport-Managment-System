using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passangers_passengersId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_myPlanePlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passangers",
                table: "Passangers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_passengersId",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Passangers");

            migrationBuilder.DropColumn(
                name: "passengersId",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "myPlanePlaneId",
                table: "Flights",
                newName: "PlaneId");

            migrationBuilder.RenameColumn(
                name: "AirlineLogo",
                table: "Flights",
                newName: "Airline");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_myPlanePlaneId",
                table: "Flights",
                newName: "IX_Flights_PlaneId");

            migrationBuilder.AlterColumn<string>(
                name: "passportNumber",
                table: "Passangers",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Passangers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "passengerspassportNumber",
                table: "FlightPassenger",
                type: "nvarchar(7)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passangers",
                table: "Passangers",
                column: "passportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "flightsflightId", "passengerspassportNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_passengerspassportNumber",
                table: "FlightPassenger",
                column: "passengerspassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passangers_passengerspassportNumber",
                table: "FlightPassenger",
                column: "passengerspassportNumber",
                principalTable: "Passangers",
                principalColumn: "passportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passangers_passengerspassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passangers",
                table: "Passangers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_passengerspassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "passengerspassportNumber",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "Flights",
                newName: "myPlanePlaneId");

            migrationBuilder.RenameColumn(
                name: "Airline",
                table: "Flights",
                newName: "AirlineLogo");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                newName: "IX_Flights_myPlanePlaneId");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Passangers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "passportNumber",
                table: "Passangers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Passangers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "passengersId",
                table: "FlightPassenger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passangers",
                table: "Passangers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "flightsflightId", "passengersId" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_passengersId",
                table: "FlightPassenger",
                column: "passengersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passangers_passengersId",
                table: "FlightPassenger",
                column: "passengersId",
                principalTable: "Passangers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_myPlanePlaneId",
                table: "Flights",
                column: "myPlanePlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
