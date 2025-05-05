namespace medicine_receipt_service.Contexts.Entities
{
    public class ProductionStepsEntity : BaseEntity
    {
        public long ReceiptId { get; set; }
        public ReceiptsEntity ReceiptsEntity { get; set; }

        public long SubstanceId { get; set; }
        public SubstancesEntity SubstancesEntity { get; set; }

        public long ProductionStepDetailId { get; set; }
        public ProductionStepDetailEntity ProductionStepDetailEntity { get; set; }

        public long NextStepId { get; set; }
        public long PrevStepId { get; set; }
    }
}
