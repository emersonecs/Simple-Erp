using AutoMapper;
using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;

namespace ERP.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _uow;

        public OrderAppService(IMapper mapper, IOrderRepository orderRepository, NotificationContext notificationContext, IUnitOfWork uow)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _notificationContext = notificationContext;
            _uow = uow;
        }

        public async Task Insert(OrderInsertViewModel orderViewModel)
        {
            var obj = _mapper.Map<Order>(orderViewModel);

            await _orderRepository.Insert(obj);


            await _uow.SaveChangesAsync();
        }
    }
}
