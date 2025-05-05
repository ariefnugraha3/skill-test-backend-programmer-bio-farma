using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicine_receipt_service.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDeletedDateOnAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "substances");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "production_step_details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "substances",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "receipts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "production_steps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "production_step_details",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
