using medicine_receipt_service.Contexts;
using medicine_receipt_service.Contexts.Entities;

namespace medicine_receipt_service.Repositories.Receipt
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReceiptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ReceiptsEntity>> GetListAsync()
        {
            try
            {
                return _dbContext.ReceiptsEntities.ToList();
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
