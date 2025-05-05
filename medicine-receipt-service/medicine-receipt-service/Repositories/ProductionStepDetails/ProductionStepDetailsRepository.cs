using medicine_receipt_service.Contexts;
using medicine_receipt_service.Contexts.Entities;

namespace medicine_receipt_service.Repositories.ProductionSteps
{
    public class ProductionStepDetailsRepository : IProductionStepDetailsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductionStepDetailsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ProductionStepDetailEntity?> GetSingleAsync(long id)
        {
            try
            {
                return await _dbContext.ProductionStepDetailsEntities.FindAsync(id);
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }
    }
}
