using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Services;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Persistence.Repositories;
using UdemyCarBook.Persistence.Repositories.CarRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
