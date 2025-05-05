using medicine_receipt_service.Contexts;
using medicine_receipt_service.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicine_receipt_service.Repositories.Receipt
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReceiptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ReceiptsEntity> Add(ReceiptsEntity entity)
        {
            try
            {
                var result = await _dbContext.ReceiptsEntities.AddAsync(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<ReceiptsEntity> Delete(ReceiptsEntity entity)
        {
            try
            {
                var result = _dbContext.ReceiptsEntities.Remove(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<List<ReceiptsEntity>> GetListAsync()
        {
            try
            {
                return await _dbContext.ReceiptsEntities.ToListAsync();
            }
            catch (Exception ex) 
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<ReceiptsEntity?> GetSingleAsync(long id)
        {
            try
            {
                return await _dbContext.ReceiptsEntities.FindAsync(id);
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<ReceiptsEntity> Update(ReceiptsEntity entity)
        {
            try
            {
                var result = _dbContext.ReceiptsEntities.Update(entity);
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
