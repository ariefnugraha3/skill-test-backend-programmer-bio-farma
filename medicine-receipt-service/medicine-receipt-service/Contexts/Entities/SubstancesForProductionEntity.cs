namespace medicine_receipt_service.Contexts.Entities
{
    public class SubstancesForProductionEntity : BaseEntity
    {
        public long ReceiptId { get; set; }
        public ReceiptsEntity ReceiptsEntity { get; set; }

        public long SubstanceId { get; set; }
        public SubstancesEntity SubstancesEntity { get; set; }

        public long ProductionStepId { get; set; }
        public ProductionStepsEntity ProductionStepsEntity { get; set; }

        public long NextStepId { get; set; }
        public long PrevStepId { get; set; }
    }
}
