using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler 
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand request)
        {
             var values = await _repository.GetByIdAsync(request.AddressId);
values.UserId = request.UserId;
values.District = request.District;
values.City = request.City;
values.Detail1 = request.Detail1;
values.Detail2 = request.Detail2;  
            values.Country = request.Country;
            values.Description = request.Description;
            values.Email = request.Email;
            values.Name = request.Name;
            values.Phone = request.Phone;
            values.Surname = request.Surname;
            values.ZipCode = request.ZipCode;

await _repository.UpdateAsync(values);}}}