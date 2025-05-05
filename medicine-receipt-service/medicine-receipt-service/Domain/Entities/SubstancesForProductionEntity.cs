namespace medicine_receipt_service.Domain.Entities
{
    public class SubstancesForProductionEntity : BaseEntity
    {
        public int ReceiptId { get; set; }
        public ReceiptsEntity ReceiptsEntity { get; set; }

        public int SubstanceId { get; set; }
        public SubstancesEntity SubstancesEntity { get; set; }

        public int ProductionStepId { get; set; }
        public ProductionStepsEntity ProductionStepsEntity { get; set; }

        public int NextStepId { get; set; }
        public int PrevStepId { get; set; }
    }
}
