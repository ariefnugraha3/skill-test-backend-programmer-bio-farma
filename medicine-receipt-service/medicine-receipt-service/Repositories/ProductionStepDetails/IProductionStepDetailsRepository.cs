using medicine_receipt_service.Contexts.Entities;

namespace medicine_receipt_service.Repositories.ProductionSteps
{
    public interface IProductionStepDetailsRepository
    {
        public Task<ProductionStepDetailEntity?> GetSingleAsync(long id);
    }
}
