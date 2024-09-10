using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address{
               UserId = createAddressCommand.UserId,
               City = createAddressCommand.City,
               District = createAddressCommand.District,
               Detail1 = createAddressCommand.Detail1,
                Detail2 = createAddressCommand.Detail2,
                Country = createAddressCommand.Country,
                Name = createAddressCommand.Name,
                Surname = createAddressCommand.Surname,
                Email = createAddressCommand.Email,
                Phone = createAddressCommand.Phone,
                ZipCode = createAddressCommand.ZipCode,
                Description = createAddressCommand.Description,


            });
        }
    }
}
