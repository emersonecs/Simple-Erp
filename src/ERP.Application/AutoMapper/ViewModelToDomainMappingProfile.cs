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
        }
    }
}
