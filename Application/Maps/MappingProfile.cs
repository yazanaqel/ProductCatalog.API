using Application.Dtos.Categories;
using Application.Dtos.Products;
using Application.Dtos.Users;
using Application.Entities.Categories;
using Application.Entities.Products;
using Application.Entities.Users;
using AutoMapper;

namespace Application.Maps;
internal class MappingProfile : Profile {

    public MappingProfile() {

        //User Maps

        CreateMap<UserRegisterDto, ApplicationUser>();
        CreateMap<UserLoginDto, ApplicationUser>();

        CreateMap<ApplicationUser, UserResponseDto>();
        CreateMap<ApplicationResponse<ApplicationUser>, ApplicationResponse<UserResponseDto>>();


        // Category Maps
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<CategoryUpdateDto, Category>();

        CreateMap<Category, CategoryResponseDto>();
        CreateMap<ApplicationResponse<Category>, ApplicationResponse<CategoryResponseDto>>();


        //Product Maps

        CreateMap<ProductCreateDto, Product>();
        CreateMap<ProductUpdateDto, Product>();

        CreateMap<Product, ProductResponseDto>();
        CreateMap<ApplicationResponse<Product>, ApplicationResponse<ProductResponseDto>>();
    }
}
