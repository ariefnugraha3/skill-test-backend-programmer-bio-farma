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

        public async Task<ProductionStepDetailEntity> Add(ProductionStepDetailEntity entity)
        {
            try
            {
                var result = await _dbContext.ProductionStepDetailsEntities.AddAsync(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<ProductionStepDetailEntity> Delete(ProductionStepDetailEntity entity)
        {
            try
            {
                var result = _dbContext.ProductionStepDetailsEntities.Remove(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
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

        public async Task<ProductionStepDetailEntity> Update(ProductionStepDetailEntity entity)
        {
            try
            {
                var result = _dbContext.ProductionStepDetailsEntities.Update(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }
    }
}
