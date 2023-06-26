using AutoMapper;
using ERP.Application.ViewModels;
using ERP.Domain.Models;

namespace ERP.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryInsertViewModel, Category>()
                .ConstructUsing(x => new Category(x.Name, x.Description));

            CreateMap<SupplierInsertViewModel, Supplier>()
                .ConstructUsing(x => new Supplier(x.Name, x.Address, x.PhoneNumber, x.Email));

            CreateMap<ProductInsertViewModel, Product>()
                .ConstructUsing(x => new Product(x.Name, x.Description, x.BarCode, x.Price, x.StockQuantity, x.SupplierId, x.CategoryId));

            CreateMap<ClientInsertViewModel, Client>()
                .ConstructUsing(x => new Client(x.Name, x.Address, x.District, x.Number, x.Email, x.Phone));

            CreateMap<OrderInsertViewModel, Order>()
                .ConstructUsing(x => new Order(x.ClientId, x.PaymentMethod, x.Total));
        }
    }
}
