using medicine_receipt_service.Dtos.GetListOfReceipt;
using medicine_receipt_service.Dtos.GetReceiptDetail;
using medicine_receipt_service.Services.Receipt;
using Microsoft.AspNetCore.Mvc;

namespace medicine_receipt_service.Controllers.Query
{

    [ApiController]
    public class ReceiptQueryController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptQueryController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("/receipt")]
        public Task<ActionResult<List<GetListOfReceiptResponseDto>>> GetList()
        {
            return _receiptService.GetListAsync();
        }

        [HttpGet]
        [Route("/receipt/{id}")]
        [Produces("application/json")]
        public Task<ActionResult<GetReceiptDetailResponseDto>> GetDetail([FromRoute] long id)
        {
            return _receiptService.GetDetailAsync(id);
        }

    }
}
