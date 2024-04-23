namespace MultiShop.Cargo.Dto.Dtos.CargoDetailDtos
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailId { get; set; }

        public string SenderCustomerId { get; set; }

        public string ReceiverCustomerId { get; set; }

        public int Barcode { get; set; }

        public int CargoCompanyId { get; set; }
    }
}
