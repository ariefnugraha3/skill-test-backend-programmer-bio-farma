namespace medicine_receipt_service.Contexts.Entities
{
    public class ProductionStepDetailEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        public float Temperature { get; set; }
        public float Pressure { get; set; }

        public ICollection<ProductionStepsEntity> SubstancesForProductions { get; set; }
    }
}
