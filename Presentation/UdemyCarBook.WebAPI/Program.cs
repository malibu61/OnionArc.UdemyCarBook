using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.PricingInterfaces;
using UdemyCarBook.Application.Services;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Persistence.Repositories;
using UdemyCarBook.Persistence.Repositories.BlogRepository;
using UdemyCarBook.Persistence.Repositories.CarRepositories;
using UdemyCarBook.Persistence.Repositories.CarPricingRepositories;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Persistence.Repositories.TagCloudRepositories;
using UdemyCarBook.Application.Features.RepositoryDesign;
using UdemyCarBook.Persistence.Repositories.CommentRepositories;
using UdemyCarBook.Application.Interfaces.LocationInterfaces;
using UdemyCarBook.Persistence.Repositories.LocationRepositories;
using UdemyCarBook.Application.Interfaces.AuthorInterfaces;
using UdemyCarBook.Persistence.Repositories.AuthorRepositories;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Persistence.Repositories.StatisticsRepositories;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Persistence.Repositories.RentACarRepositories;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Persistence.Repositories.CarFeatureRepositories;
using UdemyCarBook.Application.Interfaces.FeatureInterfaces;
using UdemyCarBook.Persistence.Repositories.FeatureRepositories;
using UdemyCarBook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarBook.Persistence.Repositories.CarDescriptionRepositories;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;
using UdemyCarBook.Persistence.Repositories.ReviewRepositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UdemyCarBook.Application.Tools;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Persistence.Repositories.AppUserRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false; //https olmayanlar da ulaþabilsin mi?
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});


builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(ILocationRepository), typeof(LocationRepository));
builder.Services.AddScoped(typeof(IAuthorRepository), typeof(AuthorRepository));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(IFeatureRepository), typeof(FeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
builder.Services.AddScoped(typeof(IAppUserRepository), typeof(AppUserRepository));

builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutHandler>();
builder.Services.AddScoped<UpdateAboutHandler>();
builder.Services.AddScoped<RemoveAboutHandler>();

builder.Services.AddScoped<GetBannerByIdQueryHandle>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<CreateBannerHandler>();
builder.Services.AddScoped<UpdateBannerHandler>();
builder.Services.AddScoped<RemoveBannerHandler>();


builder.Services.AddScoped<GetBrandByIdHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<CreateBrandHandler>();
builder.Services.AddScoped<UpdateBrandHandler>();
builder.Services.AddScoped<RemoveBrandHandler>();

builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<CreateCarHandler>();
builder.Services.AddScoped<UpdateCarHandler>();
builder.Services.AddScoped<RemoveCarHandler>();
builder.Services.AddScoped<GetCarByBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandsQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandByCarIdQueryHandler>();

builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<CreateCategoryHandler>();
builder.Services.AddScoped<UpdateCategoryHandler>();
builder.Services.AddScoped<RemoveCategoryHandler>();


builder.Services.AddScoped<GetContactByIdHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<CreateContactHandler>();
builder.Services.AddScoped<UpdateContactHandler>();
builder.Services.AddScoped<RemoveContactHandler>();


//builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
