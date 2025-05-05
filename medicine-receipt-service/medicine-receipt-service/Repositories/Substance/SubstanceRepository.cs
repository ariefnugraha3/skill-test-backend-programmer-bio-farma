using medicine_receipt_service.Contexts;
using medicine_receipt_service.Contexts.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace medicine_receipt_service.Repositories.Substance
{
    public class SubstanceRepository : ISubstanceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SubstanceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SubstancesEntity> Add(SubstancesEntity entity)
        {
            try
            {
                var result = await _dbContext.SubstancesEntities.AddAsync(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<SubstancesEntity> Delete(SubstancesEntity entity)
        {
            try
            {
                var result = _dbContext.SubstancesEntities.Remove(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<List<SubstancesEntity>> GetMany(Expression<Func<SubstancesEntity, bool>> predicate)
        {
            try
            {
                return await _dbContext.SubstancesEntities.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<SubstancesEntity?> GetSingleAsync(long id)
        {
            try
            {
                return await _dbContext.SubstancesEntities.FindAsync(id);
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
        }

        public async Task<SubstancesEntity> Update(SubstancesEntity entity)
        {
            try
            {
                var result = _dbContext.SubstancesEntities.Update(entity);
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
