using medicine_receipt_service.Contexts.Entities;

namespace medicine_receipt_service.Repositories.ProductionSteps
{
    public interface IProductionStepDetailsRepository
    {
        public Task<ProductionStepDetailEntity?> GetSingleAsync(long id);
        public Task<ProductionStepDetailEntity> Add(ProductionStepDetailEntity entity);
        public Task<ProductionStepDetailEntity> Update(ProductionStepDetailEntity entity);
        public Task<ProductionStepDetailEntity> Delete(ProductionStepDetailEntity entity);
    }
}
