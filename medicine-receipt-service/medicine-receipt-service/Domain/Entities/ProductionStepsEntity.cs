namespace medicine_receipt_service.Domain.Entities
{
    public class ProductionStepsEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        public float Temperature { get; set; }
        public float Pressure { get; set; }

        public ICollection<SubstancesForProductionEntity> SubstancesForProductions { get; set; }
    }
}
