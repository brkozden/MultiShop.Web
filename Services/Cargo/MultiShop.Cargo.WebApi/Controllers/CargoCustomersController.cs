using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdCargoCustomer(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto cargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = cargoCustomerDto.Name,
                Surname = cargoCustomerDto.Surname,
                Phone = cargoCustomerDto.Phone,
                Email = cargoCustomerDto.Email,
                District = cargoCustomerDto.District,
                City = cargoCustomerDto.City,
                Address = cargoCustomerDto.Address,
                UserCustomerId = cargoCustomerDto.UserCustomerId,
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo Müşterisi Başarıyla Oluşturuldu.");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Çalışanı Başarıyla Silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto cargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
               CargoCustomerId = cargoCustomerDto.CargoCustomerId,  
               Name = cargoCustomerDto.Name,
               Surname = cargoCustomerDto.Surname,
               Phone = cargoCustomerDto.Phone,
               Email = cargoCustomerDto.Email,
               District = cargoCustomerDto.District,
               City = cargoCustomerDto.City,
               Address = cargoCustomerDto.Address,
               UserCustomerId = cargoCustomerDto.UserCustomerId,
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo Müşterisi Başarıyla Güncellendi.");
        }
        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomerById(string id)
        {
            return Ok(_cargoCustomerService.TGetCargoCustomerById(id));
        }
    }
}
