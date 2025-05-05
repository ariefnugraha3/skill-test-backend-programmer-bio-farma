using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicine_receipt_service.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubstancesForProductionEntities_ProductionStepsEntities_Pro~",
                table: "SubstancesForProductionEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_SubstancesForProductionEntities_ReceiptsEntities_ReceiptId",
                table: "SubstancesForProductionEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_SubstancesForProductionEntities_SubstancesEntities_Substanc~",
                table: "SubstancesForProductionEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersEntity",
                table: "UsersEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubstancesForProductionEntities",
                table: "SubstancesForProductionEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubstancesEntities",
                table: "SubstancesEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptsEntities",
                table: "ReceiptsEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductionStepsEntities",
                table: "ProductionStepsEntities");

            migrationBuilder.RenameTable(
                name: "UsersEntity",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "SubstancesForProductionEntities",
                newName: "substance_for_productions");

            migrationBuilder.RenameTable(
                name: "SubstancesEntities",
                newName: "substances");

            migrationBuilder.RenameTable(
                name: "ReceiptsEntities",
                newName: "receipts");

            migrationBuilder.RenameTable(
                name: "ProductionStepsEntities",
                newName: "production_steps");

            migrationBuilder.RenameIndex(
                name: "IX_SubstancesForProductionEntities_SubstanceId",
                table: "substance_for_productions",
                newName: "IX_substance_for_productions_SubstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_SubstancesForProductionEntities_ReceiptId_SubstanceId_Produ~",
                table: "substance_for_productions",
                newName: "IX_substance_for_productions_ReceiptId_SubstanceId_ProductionS~");

            migrationBuilder.RenameIndex(
                name: "IX_SubstancesForProductionEntities_ProductionStepId",
                table: "substance_for_productions",
                newName: "IX_substance_for_productions_ProductionStepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_substance_for_productions",
                table: "substance_for_productions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_substances",
                table: "substances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_receipts",
                table: "receipts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_production_steps",
                table: "production_steps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_substance_for_productions_production_steps_ProductionStepId",
                table: "substance_for_productions",
                column: "ProductionStepId",
                principalTable: "production_steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_substance_for_productions_receipts_ReceiptId",
                table: "substance_for_productions",
                column: "ReceiptId",
                principalTable: "receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_substance_for_productions_substances_SubstanceId",
                table: "substance_for_productions",
                column: "SubstanceId",
                principalTable: "substances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_substance_for_productions_production_steps_ProductionStepId",
                table: "substance_for_productions");

            migrationBuilder.DropForeignKey(
                name: "FK_substance_for_productions_receipts_ReceiptId",
                table: "substance_for_productions");

            migrationBuilder.DropForeignKey(
                name: "FK_substance_for_productions_substances_SubstanceId",
                table: "substance_for_productions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_substances",
                table: "substances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_substance_for_productions",
                table: "substance_for_productions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_receipts",
                table: "receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_production_steps",
                table: "production_steps");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "UsersEntity");

            migrationBuilder.RenameTable(
                name: "substances",
                newName: "SubstancesEntities");

            migrationBuilder.RenameTable(
                name: "substance_for_productions",
                newName: "SubstancesForProductionEntities");

            migrationBuilder.RenameTable(
                name: "receipts",
                newName: "ReceiptsEntities");

            migrationBuilder.RenameTable(
                name: "production_steps",
                newName: "ProductionStepsEntities");

            migrationBuilder.RenameIndex(
                name: "IX_substance_for_productions_SubstanceId",
                table: "SubstancesForProductionEntities",
                newName: "IX_SubstancesForProductionEntities_SubstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_substance_for_productions_ReceiptId_SubstanceId_ProductionS~",
                table: "SubstancesForProductionEntities",
                newName: "IX_SubstancesForProductionEntities_ReceiptId_SubstanceId_Produ~");

            migrationBuilder.RenameIndex(
                name: "IX_substance_for_productions_ProductionStepId",
                table: "SubstancesForProductionEntities",
                newName: "IX_SubstancesForProductionEntities_ProductionStepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersEntity",
                table: "UsersEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubstancesEntities",
                table: "SubstancesEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubstancesForProductionEntities",
                table: "SubstancesForProductionEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptsEntities",
                table: "ReceiptsEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductionStepsEntities",
                table: "ProductionStepsEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubstancesForProductionEntities_ProductionStepsEntities_Pro~",
                table: "SubstancesForProductionEntities",
                column: "ProductionStepId",
                principalTable: "ProductionStepsEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubstancesForProductionEntities_ReceiptsEntities_ReceiptId",
                table: "SubstancesForProductionEntities",
                column: "ReceiptId",
                principalTable: "ReceiptsEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubstancesForProductionEntities_SubstancesEntities_Substanc~",
                table: "SubstancesForProductionEntities",
                column: "SubstanceId",
                principalTable: "SubstancesEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
