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
    public class CreateAddressCommandHandler 
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand request)
        {
            await _repository.CreateAsync(new Address
            {
                UserId = request.UserId,
District = request.District,
City = request.City,
Detail1 = request.Detail1,
Detail2 = request.Detail2,
Country = request.Country,
Description = request.Description,
Email = request.Email,
Name = request.Name,
Phone = request.Phone,
Surname = request.Surname,
ZipCode = request.ZipCode
});
        }
    }
}
