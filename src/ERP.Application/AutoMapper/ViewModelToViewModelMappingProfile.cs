using AutoMapper;
using ERP.Application.ViewModels;

namespace ERP.Application.AutoMapper
{
    public class ViewModelToViewModelMappingProfile : Profile
    {
        public ViewModelToViewModelMappingProfile()
        {
            CreateMap<ProductViewModel, ProductEditViewModel>();
            CreateMap<SupplierViewModel, SupplierEditViewModel>();
            CreateMap<CategoryViewModel, CategoryEditViewModel>();
        }
    }
}
