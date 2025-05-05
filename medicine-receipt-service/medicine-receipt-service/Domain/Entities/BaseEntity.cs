namespace medicine_receipt_service.Domain.Entities
{
    public class BaseEntity
    { 
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; } = null;
    }
}
