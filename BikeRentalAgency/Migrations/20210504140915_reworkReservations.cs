using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeRentalAgency.Migrations
{
    public partial class reworkReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationDetails");

            migrationBuilder.AddColumn<int>(
                name: "ReservationID",
                table: "SpecialFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BikeQuantity",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialFeatures_ReservationID",
                table: "SpecialFeatures",
                column: "ReservationID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialFeatures_Reservations_ReservationID",
                table: "SpecialFeatures",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialFeatures_Reservations_ReservationID",
                table: "SpecialFeatures");

            migrationBuilder.DropIndex(
                name: "IX_SpecialFeatures_ReservationID",
                table: "SpecialFeatures");

            migrationBuilder.DropColumn(
                name: "ReservationID",
                table: "SpecialFeatures");

            migrationBuilder.DropColumn(
                name: "BikeQuantity",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Reservations");

            migrationBuilder.CreateTable(
                name: "ReservationDetails",
                columns: table => new
                {
                    BikeQuantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationID = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
