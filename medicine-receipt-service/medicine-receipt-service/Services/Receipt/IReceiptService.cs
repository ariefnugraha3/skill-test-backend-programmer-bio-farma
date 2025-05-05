using medicine_receipt_service.Dtos.GetListOfReceipt;
using Microsoft.AspNetCore.Mvc;

namespace medicine_receipt_service.Services.Receipt
{
    public interface IReceiptService
    {
        public Task<ActionResult<List<GetListOfReceiptResponseDto>>> GetListAsync();
    }
}
