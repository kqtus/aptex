using System;
using AutoMapper;

using Aptex.Contracts.Models;
using Aptex.Contracts.ViewModels;

namespace Aptex.Contracts.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductReception, opt => opt.MapFrom(src => src.Reception));

            CreateMap<ProductViewModel, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Reception, opt => opt.MapFrom(src => src.ProductReception));

            CreateMap<Category, CategorySelectViewModel>();
            CreateMap<CategorySelectViewModel, Category>();
        }
    }
}