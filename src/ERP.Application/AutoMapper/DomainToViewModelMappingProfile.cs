using AutoMapper;
using ERP.Application.ViewModels;
using ERP.Domain.Models;

namespace ERP.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Client, ClientViewModel>();
        }
    }
}
