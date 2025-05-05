namespace medicine_receipt_service.Domain.Entities
{
    public class SubstancesEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<SubstancesForProductionEntity> SubstancesForProductions { get; set; }
    }
}
