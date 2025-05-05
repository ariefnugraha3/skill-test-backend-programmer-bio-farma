namespace medicine_receipt_service.Dtos.GetReceiptDetail
{
    public class GetReceiptDetailResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductionStepDetailDto> ProductionSteps { get; set; }
    }

    public class ProductionStepDetailDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        public float Temperature { get; set; }
        public float Pressure { get; set; }
        public List<SubstanceDto> Substances { get; set; }
    }

    public class SubstanceDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
