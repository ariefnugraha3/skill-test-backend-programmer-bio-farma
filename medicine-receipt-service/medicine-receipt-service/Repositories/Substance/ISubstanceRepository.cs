using medicine_receipt_service.Contexts.Entities;
using System.Linq.Expressions;

namespace medicine_receipt_service.Repositories.Substance
{
    public interface ISubstanceRepository
    {
        public Task<SubstancesEntity?> GetSingleAsync(long id);
        public Task<List<SubstancesEntity>> GetMany(Expression<Func<SubstancesEntity, bool>> predicate);
    }
}
