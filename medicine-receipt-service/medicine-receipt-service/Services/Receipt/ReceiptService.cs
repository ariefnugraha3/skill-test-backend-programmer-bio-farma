using medicine_receipt_service.Dtos.GetListOfReceipt;
using medicine_receipt_service.Repositories.Receipt;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace medicine_receipt_service.Services.Receipt
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<ActionResult<List<GetListOfReceiptResponseDto>>> GetListAsync()
        {
            try
            {
                var receiptEntities = await _receiptRepository.GetListAsync();
                var response = new List<GetListOfReceiptResponseDto>();

                foreach (var receipt in receiptEntities)
                {
                    response.Add(new()
                    {
                        Id = receipt.Id,
                        Name = receipt.Name,
                        Description = receipt.Description,
                    });
                }

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                //TODO: log ex
                return new ObjectResult("Internal server error")
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
