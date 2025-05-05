using medicine_receipt_service.Contexts;
using medicine_receipt_service.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicine_receipt_service.Repositories.SubstanceForProduction
{
    public class ProductionStepsRepository : IProductionStepsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductionStepsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductionStepsEntity> Add(ProductionStepsEntity entity)
        {
            try
            {
                var result = await _dbContext.ProductionStepsEntities.AddAsync(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<ProductionStepsEntity> Delete(ProductionStepsEntity entity)
        {
            try
            {
                var result = _dbContext.ProductionStepsEntities.Remove(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<List<ProductionStepsEntity>> GetListByReceiptIdAsync(long receiptId)
        {
            try
            {
                return await _dbContext.ProductionStepsEntities
                    .Where(productionStep => productionStep.ReceiptId == receiptId)
                    .OrderBy(substanceForProduction => substanceForProduction.CreateDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<ProductionStepsEntity?> GetSingleAsync(long id)
        {
            try
            {
                return await _dbContext.ProductionStepsEntities.FindAsync(id);
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<ProductionStepsEntity> Update(ProductionStepsEntity entity)
        {
            try
            {
                var result = _dbContext.ProductionStepsEntities.Update(entity);
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
