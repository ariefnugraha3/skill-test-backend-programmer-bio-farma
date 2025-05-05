using medicine_receipt_service.Contexts.Entities;

namespace medicine_receipt_service.Repositories.Receipt
{
    public interface IReceiptRepository
    {
        public Task<List<ReceiptsEntity>> GetListAsync();
        public Task<ReceiptsEntity?> GetSingleAsync(long id);
    }
}
