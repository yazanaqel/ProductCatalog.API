using Application.Application.Abstractions;
using Application.Entities.Categories;
using Application.Entities.Products;
using Application.Entities.Users;
using Infrastructure.SqlServerDb;
using Infrastructure.SqlServerDb.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

        services.AddDbContext<ProductCategoryDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });


        services.AddIdentity<ApplicationUser, IdentityRole>(op => {
            op.Password.RequireDigit = false;
            op.Password.RequiredLength = 6;
            op.Password.RequireUppercase = false;
            op.Password.RequireLowercase = false;
            op.Password.RequireNonAlphanumeric = false;
            op.SignIn.RequireConfirmedAccount = false;
            op.ClaimsIdentity.UserIdClaimType = "UserId";
        })
    .AddEntityFrameworkStores<ProductCategoryDbContext>();

        services.AddScoped<IDbContext>(factory => factory.GetRequiredService<ProductCategoryDbContext>());

        services.AddScoped<IUserService, UserRepository>();
        services.AddScoped<ICategoryService, CategoryRepository>();
        services.AddScoped<IProductService, ProductRepository>();

        return services;
    }

    public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration configuration) {

        services.Configure<HelperJWT>(configuration.GetSection(nameof(HelperJWT)));

        //services.AddAuthentication(options => {
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //})
        //.AddJwtBearer(o => {
        //    o.RequireHttpsMetadata = false;
        //    o.SaveToken = false;
        //    o.TokenValidationParameters = new TokenValidationParameters {
        //        ValidateIssuerSigningKey = true,
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidIssuer = configuration["HelperJWT:Issuer"],
        //        ValidAudience = configuration["HelperJWT:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["HelperJWT:Key"]))
        //    };
        //});

        return services;
    }
}
