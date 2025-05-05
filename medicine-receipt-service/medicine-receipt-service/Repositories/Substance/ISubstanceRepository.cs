using medicine_receipt_service.Contexts.Entities;
using System.Linq.Expressions;

namespace medicine_receipt_service.Repositories.Substance
{
    public interface ISubstanceRepository
    {
        public Task<SubstancesEntity?> GetSingleAsync(long id);
        public Task<List<SubstancesEntity>> GetMany(Expression<Func<SubstancesEntity, bool>> predicate);
        public Task<SubstancesEntity> Add(SubstancesEntity entity);
        public Task<SubstancesEntity> Update(SubstancesEntity entity);
        public Task<SubstancesEntity> Delete(SubstancesEntity entity);
    }
}
