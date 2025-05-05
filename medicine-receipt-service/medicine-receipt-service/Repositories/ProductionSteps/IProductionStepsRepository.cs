using medicine_receipt_service.Contexts.Entities;

namespace medicine_receipt_service.Repositories.SubstanceForProduction
{
    public interface IProductionStepsRepository
    {
        public Task<List<ProductionStepsEntity>> GetListByReceiptIdAsync(long receiptId);
        public Task<ProductionStepsEntity?> GetSingleAsync(long id);
        public Task<ProductionStepsEntity> Add(ProductionStepsEntity entity);
        public Task<ProductionStepsEntity> Update(ProductionStepsEntity entity);
        public Task<ProductionStepsEntity> Delete(ProductionStepsEntity entity);
    }
}
