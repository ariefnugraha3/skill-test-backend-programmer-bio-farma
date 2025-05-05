using medicine_receipt_service.Dtos.GetListOfReceipt;
using medicine_receipt_service.Services.Receipt;
using Microsoft.AspNetCore.Mvc;

namespace medicine_receipt_service.Controllers.Query
{

    [ApiController]
    [Route("/receipt")]
    public class ReceiptQueryController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptQueryController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpGet]
        [Produces("application/json")]
        public Task<ActionResult<List<GetListOfReceiptResponseDto>>> GetList()
        {
            return _receiptService.GetListAsync();
        }

    }
}
