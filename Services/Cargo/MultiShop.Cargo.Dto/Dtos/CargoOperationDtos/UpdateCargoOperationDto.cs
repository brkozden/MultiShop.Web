﻿namespace MultiShop.Cargo.Dto.Dtos.CargoOperationDtos
{
    public class UpdateCargoOperationDto
    {
        public int CargoOperationId { get; set; }

        public string Barcode { get; set; }
        public string Description { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
