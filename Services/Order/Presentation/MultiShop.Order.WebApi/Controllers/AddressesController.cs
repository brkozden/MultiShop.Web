﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _addressQueryHandler;
        private readonly GetAddressByIdQueryHandler _addressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler addressQueryHandler, GetAddressByIdQueryHandler addressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler)
        {
            _addressQueryHandler = addressQueryHandler;
            _addressByIdQueryHandler = addressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
        }
        [HttpGet]

        public async Task<IActionResult> AddressList()
        {
            var values = await _addressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetAddressById(int id)
        {
            var value = await _addressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi Başarıyla Eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Adres Bilgisi Başarıyla Silindi.");
        }
    }
}
