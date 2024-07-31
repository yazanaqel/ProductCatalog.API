using Application.Dtos.Categories;
using Application.Dtos.Users;
using Application.Entities.Categories;
using Application.Entities.Users;
using AutoMapper;

namespace Application.Maps;
internal class MappingProfile : Profile {

    public MappingProfile() {

        CreateMap<UserRegisterDto, ApplicationUser>();
        CreateMap<UserLoginDto, ApplicationUser>();

        CreateMap<ApplicationUser, UserResponseDto>();
        CreateMap<ApplicationResponse<ApplicationUser>, ApplicationResponse<UserResponseDto>>();



        CreateMap<CategoryCreateDto, Category>();

        CreateMap<Category, CategoryResponseDto>();
        CreateMap<ApplicationResponse<Category>, ApplicationResponse<CategoryResponseDto>>();

    }
}
