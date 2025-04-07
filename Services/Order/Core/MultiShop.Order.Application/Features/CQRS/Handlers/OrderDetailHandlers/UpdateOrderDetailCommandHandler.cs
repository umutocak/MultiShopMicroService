using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _repository.GetByIdAsync(updateOrderDetailCommand.Id);
            values.OrderingId = updateOrderDetailCommand.OrderingId;
            values.ProductId = updateOrderDetailCommand.ProductId;
            values.ProductPrice = updateOrderDetailCommand.ProductPrice;
            values.ProductName = updateOrderDetailCommand.ProductName;
            values.TotalPrice = updateOrderDetailCommand.TotalPrice;
            values.ProductAmount = updateOrderDetailCommand.ProductAmount;
            await _repository.UpdateAsync(values);
        }
    }
}
