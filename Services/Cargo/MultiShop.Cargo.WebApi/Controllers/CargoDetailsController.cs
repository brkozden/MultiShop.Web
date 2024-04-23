using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoDetailDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdCargoDetail(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto cargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = cargoDetailDto.Barcode,
                ReceiverCustomerId = cargoDetailDto.ReceiverCustomerId,
                SenderCustomerId = cargoDetailDto.SenderCustomerId,
                CargoCompanyId = cargoDetailDto.CargoCompanyId
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo Detayı Başarıyla Oluşturuldu.");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Detayı Başarıyla Silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto cargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
           Barcode = cargoDetailDto.Barcode,
           ReceiverCustomerId = cargoDetailDto.ReceiverCustomerId,
           SenderCustomerId = cargoDetailDto.SenderCustomerId,
           CargoDetailId = cargoDetailDto.CargoDetailId,
           CargoCompanyId = cargoDetailDto.CargoCompanyId
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo Detayı Başarıyla Güncellendi.");
        }
    }
}
