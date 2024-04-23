using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoOperationDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdCargoOperation(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto cargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = cargoOperationDto.Barcode,
                Description = cargoOperationDto.Description,
                OperationDate = cargoOperationDto.OperationDate,
            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo Hareketi Başarıyla Oluşturuldu.");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Hareketi Başarıyla Silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto cargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
               Barcode=cargoOperationDto.Barcode,
               Description=cargoOperationDto.Description,
               OperationDate=cargoOperationDto.OperationDate,
               CargoOperationId = cargoOperationDto.CargoOperationId
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo Hareketi Başarıyla Güncellendi.");
        }
    }
}
