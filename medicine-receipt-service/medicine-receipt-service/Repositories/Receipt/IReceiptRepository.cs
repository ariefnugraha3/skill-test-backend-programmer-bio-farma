using medicine_receipt_service.Contexts.Entities;
using medicine_receipt_service.Dtos.GetListOfReceipt;

namespace medicine_receipt_service.Repositories.Receipt
{
    public interface IReceiptRepository
    {
        public Task<List<ReceiptsEntity>> GetListAsync();
    }
}
