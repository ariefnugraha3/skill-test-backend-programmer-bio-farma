using medicine_receipt_service.Contexts.Entities;
using medicine_receipt_service.Dtos.GetListOfReceipt;
using medicine_receipt_service.Dtos.GetReceiptDetail;
using medicine_receipt_service.Repositories.ProductionSteps;
using medicine_receipt_service.Repositories.Receipt;
using medicine_receipt_service.Repositories.Substance;
using medicine_receipt_service.Repositories.SubstanceForProduction;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace medicine_receipt_service.Services.Receipt
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IProductionStepDetailsRepository _productionStepDetailsRepository;
        private readonly ISubstanceRepository _substanceRepository;
        private readonly IProductionStepsRepository _productionStepsRepository;

        public ReceiptService(
            IReceiptRepository receiptRepository,
            IProductionStepDetailsRepository productionStepDetailsRepository,
            ISubstanceRepository substanceRepository,
            IProductionStepsRepository productionStepsRepository)
        {
            _receiptRepository = receiptRepository;
            _productionStepsRepository = productionStepsRepository;
            _substanceRepository = substanceRepository;
            _productionStepDetailsRepository = productionStepDetailsRepository;
        }

        public async Task<ActionResult<GetReceiptDetailResponseDto>> GetDetailAsync(long id)
        {
            try
            {
                var receiptEntity = await _receiptRepository.GetSingleAsync(id);
                if (receiptEntity == null) 
                    return new NotFoundObjectResult(HttpStatusCode.NotFound);

                var productionSteps = await _productionStepsRepository.GetListByReceiptIdAsync(receiptEntity.Id);
                if(receiptEntity == null)
                    return new NotFoundObjectResult(HttpStatusCode.NotFound);

                var response = new GetReceiptDetailResponseDto
                {
                    Id = receiptEntity.Id,
                    Name = receiptEntity.Name,
                    Description = receiptEntity.Description,
                    ProductionSteps = []
                };

                foreach (var productionStep in productionSteps.DistinctBy(step => step.ProductionStepDetailId))
                {
                    var productionStepDetailEntity = await _productionStepDetailsRepository.GetSingleAsync(productionStep.ProductionStepDetailId);
                    response.ProductionSteps.Add(new()
                    {
                        Id = productionStepDetailEntity.Id,
                        Name = productionStepDetailEntity.Name,
                        Description = productionStepDetailEntity.Description,
                        Duration = productionStepDetailEntity.Duration,
                        Temperature = productionStepDetailEntity.Temperature,
                        Pressure = productionStepDetailEntity.Pressure,
                        Substances = []
                    });
                }

                foreach (var productionStepResponse in response.ProductionSteps)
                {
                    var productionStepsForGetSubstance = productionSteps.Where(step => step.ReceiptId == id && step.ProductionStepDetailId == productionStepResponse.Id).ToList();
                    var subtanceDto = await GetListOfSubtanceByProductionStep(productionStepsForGetSubstance);
                    productionStepResponse.Substances = subtanceDto;
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

        private async Task<List<SubstanceDto>> GetListOfSubtanceByProductionStep(List<ProductionStepsEntity> productionStepsEntities)
        {
            try
            {
                List<SubstanceDto> substancesDtos = new();
                foreach(var productionStep in productionStepsEntities)
                {
                    var substance = await _substanceRepository.GetSingleAsync(productionStep.SubstanceId);
                    substancesDtos.Add(new()
                    {
                        Id = substance.Id,
                        Name = substance.Name,
                        Description= substance.Description
                    });
                }
                return substancesDtos;
            }
            catch (Exception ex)
            {
                //TODO : log ex
                throw;
            }
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
