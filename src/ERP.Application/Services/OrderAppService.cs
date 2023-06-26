using AutoMapper;
using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Domain.Notification;

namespace ERP.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly NotificationContext _notificationContext;

        public OrderAppService(IMapper mapper, IOrderRepository orderRepository, NotificationContext notificationContext)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _notificationContext = notificationContext;
        }

        public async Task Insert(OrderInsertViewModel orderViewModel)
        {
            var obj = _mapper.Map<Order>(orderViewModel);

            await _orderRepository.Insert(obj);
        }
    }
}
