namespace medicine_receipt_service.Contexts.Entities
{
    public class ReceiptsEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<SubstancesForProductionEntity> SubstancesForProductions { get; set; }
    }
}
