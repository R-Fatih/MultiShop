using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler 
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand request)
        {
             var values = await _repository.GetByIdAsync(request.OrderDetailId);
values.ProductId = request.ProductId;
values.ProductName = request.ProductName;
values.ProductPrice = request.ProductPrice;
values.ProductAmount = request.ProductAmount;
values.ProductTotalPrice = request.ProductTotalPrice;
values.OrderingId = request.OrderingId;

await _repository.UpdateAsync(values);}}}