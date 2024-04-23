namespace MultiShop.Cargo.Entity.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }

        public string SenderCustomerId { get; set; }

        public string ReceiverCustomerId { get; set; }

        public int Barcode { get; set; }

        public int CargoCompanyId { get; set; }

        public CargoCompany CargoCompany { get; set; }
    }
}
