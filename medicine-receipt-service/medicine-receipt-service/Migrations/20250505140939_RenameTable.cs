using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace medicine_receipt_service.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "substance_for_productions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "Pressure",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "production_steps");

            migrationBuilder.AddColumn<long>(
                name: "NextStepId",
                table: "production_steps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PrevStepId",
                table: "production_steps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductionStepId",
                table: "production_steps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReceiptId",
                table: "production_steps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SubstanceId",
                table: "production_steps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "production_step_details",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    Pressure = table.Column<float>(type: "real", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_production_step_details", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_production_steps_ProductionStepId",
                table: "production_steps",
                column: "ProductionStepId");

            migrationBuilder.CreateIndex(
                name: "IX_production_steps_ReceiptId_SubstanceId_ProductionStepId",
                table: "production_steps",
                columns: new[] { "ReceiptId", "SubstanceId", "ProductionStepId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_production_steps_SubstanceId",
                table: "production_steps",
                column: "SubstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_production_steps_production_step_details_ProductionStepId",
                table: "production_steps",
                column: "ProductionStepId",
                principalTable: "production_step_details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_production_steps_receipts_ReceiptId",
                table: "production_steps",
                column: "ReceiptId",
                principalTable: "receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_production_steps_substances_SubstanceId",
                table: "production_steps",
                column: "SubstanceId",
                principalTable: "substances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_production_steps_production_step_details_ProductionStepId",
                table: "production_steps");

            migrationBuilder.DropForeignKey(
                name: "FK_production_steps_receipts_ReceiptId",
                table: "production_steps");

            migrationBuilder.DropForeignKey(
                name: "FK_production_steps_substances_SubstanceId",
                table: "production_steps");

            migrationBuilder.DropTable(
                name: "production_step_details");

            migrationBuilder.DropIndex(
                name: "IX_production_steps_ProductionStepId",
                table: "production_steps");

            migrationBuilder.DropIndex(
                name: "IX_production_steps_ReceiptId_SubstanceId_ProductionStepId",
                table: "production_steps");

            migrationBuilder.DropIndex(
                name: "IX_production_steps_SubstanceId",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "NextStepId",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "PrevStepId",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "ProductionStepId",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "production_steps");

            migrationBuilder.DropColumn(
                name: "SubstanceId",
                table: "production_steps");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "production_steps",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Duration",
                table: "production_steps",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "production_steps",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Pressure",
                table: "production_steps",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Temperature",
                table: "production_steps",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "substance_for_productions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionStepId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiptId = table.Column<long>(type: "bigint", nullable: false),
                    SubstanceId = table.Column<long>(type: "bigint", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NextStepId = table.Column<long>(type: "bigint", nullable: false),
                    PrevStepId = table.Column<long>(type: "bigint", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_substance_for_productions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_substance_for_productions_production_steps_ProductionStepId",
                        column: x => x.ProductionStepId,
                        principalTable: "production_steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_substance_for_productions_receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_substance_for_productions_substances_SubstanceId",
                        column: x => x.SubstanceId,
                        principalTable: "substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_substance_for_productions_ProductionStepId",
                table: "substance_for_productions",
                column: "ProductionStepId");

            migrationBuilder.CreateIndex(
                name: "IX_substance_for_productions_ReceiptId_SubstanceId_ProductionS~",
                table: "substance_for_productions",
                columns: new[] { "ReceiptId", "SubstanceId", "ProductionStepId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_substance_for_productions_SubstanceId",
                table: "substance_for_productions",
                column: "SubstanceId");
        }
    }
}
