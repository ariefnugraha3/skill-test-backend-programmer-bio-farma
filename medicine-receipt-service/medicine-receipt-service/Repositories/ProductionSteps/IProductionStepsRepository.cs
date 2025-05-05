using medicine_receipt_service.Contexts.Entities;

namespace medicine_receipt_service.Repositories.SubstanceForProduction
{
    public interface IProductionStepsRepository
    {
        public Task<List<ProductionStepsEntity>> GetListByReceiptIdAsync(long receiptId);
        public Task<ProductionStepsEntity?> GetSingleAsync(long id);
    }
}
