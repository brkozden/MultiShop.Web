namespace MultiShop.Cargo.Dto.Dtos.CargoDetailDtos
{
    public class CreateCargoDetailDto
    {

        public string SenderCustomerId { get; set; }

        public string ReceiverCustomerId { get; set; }

        public int Barcode { get; set; }

        public int CargoCompanyId { get; set; }
    }
}
