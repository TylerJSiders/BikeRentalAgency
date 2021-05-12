using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeRentalAgency.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            //migrationBuilder.DropColumn(
            //    name: "BikeQuantity",
            //    table: "Reservations");

            //migrationBuilder.DropColumn(
            //    name: "Discount",
            //    table: "Reservations");

            //migrationBuilder.DropColumn(
            //    name: "PaymentType",
            //    table: "Reservations");

            //migrationBuilder.DropColumn(
            //    name: "ReservationDate",
            //    table: "Reservations");

            //migrationBuilder.DropColumn(
            //    name: "TotalPrice",
            //    table: "Reservations");

        }
    }
}
