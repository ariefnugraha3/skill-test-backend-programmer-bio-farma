using medicine_receipt_service.Dtos.GetListOfReceipt;
using medicine_receipt_service.Dtos.GetReceiptDetail;
using Microsoft.AspNetCore.Mvc;

namespace medicine_receipt_service.Services.Receipt
{
    public interface IReceiptService
    {
        public Task<ActionResult<List<GetListOfReceiptResponseDto>>> GetListAsync();
        public Task<ActionResult<GetReceiptDetailResponseDto>> GetDetailAsync(long id);
    }
}
