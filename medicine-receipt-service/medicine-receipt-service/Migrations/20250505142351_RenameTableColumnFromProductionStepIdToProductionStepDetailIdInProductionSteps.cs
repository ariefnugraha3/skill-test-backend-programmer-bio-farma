using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicine_receipt_service.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableColumnFromProductionStepIdToProductionStepDetailIdInProductionSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_production_steps_production_step_details_ProductionStepId",
                table: "production_steps");

            migrationBuilder.RenameColumn(
                name: "ProductionStepId",
                table: "production_steps",
                newName: "ProductionStepDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_production_steps_ReceiptId_SubstanceId_ProductionStepId",
                table: "production_steps",
                newName: "IX_production_steps_ReceiptId_SubstanceId_ProductionStepDetail~");

            migrationBuilder.RenameIndex(
                name: "IX_production_steps_ProductionStepId",
                table: "production_steps",
                newName: "IX_production_steps_ProductionStepDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_production_steps_production_step_details_ProductionStepDeta~",
                table: "production_steps",
                column: "ProductionStepDetailId",
                principalTable: "production_step_details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_production_steps_production_step_details_ProductionStepDeta~",
                table: "production_steps");

            migrationBuilder.RenameColumn(
                name: "ProductionStepDetailId",
                table: "production_steps",
                newName: "ProductionStepId");

            migrationBuilder.RenameIndex(
                name: "IX_production_steps_ReceiptId_SubstanceId_ProductionStepDetail~",
                table: "production_steps",
                newName: "IX_production_steps_ReceiptId_SubstanceId_ProductionStepId");

            migrationBuilder.RenameIndex(
                name: "IX_production_steps_ProductionStepDetailId",
                table: "production_steps",
                newName: "IX_production_steps_ProductionStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_production_steps_production_step_details_ProductionStepId",
                table: "production_steps",
                column: "ProductionStepId",
                principalTable: "production_step_details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
