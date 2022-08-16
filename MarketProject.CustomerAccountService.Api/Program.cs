using FluentValidation;
using FluentValidation.AspNetCore;
using MarketProject.CustomerAccountService.Application;
using MarketProject.CustomerAccountService.Application.Interfaces;
using MarketProject.CustomerAccountService.Domain.MapperProfiles;
using MarketProject.CustomerAccountService.Domain.Validators;
using MarketProject.CustomerAccountService.Persistence.CQRS.Commands;
using MarketProject.CustomerAccountService.Persistence.CQRS.Commands.Interfaces;
using MarketProject.CustomerAccountService.Persistence.CQRS.Queries;
using MarketProject.CustomerAccountService.Persistence.CQRS.Queries.Interfaces;
using MarketProject.CustomerAccountService.Persistence.Repositories;
using MarketProject.CustomerAccountService.Persistence.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(AddressValidator));
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerAccountApplication, CustomerAccountApplication>();
builder.Services.AddSingleton<ICustomerAccountRepository, CustomerAccountRepository>();
builder.Services.AddScoped<IGetCustomerAccountQuery, GetCustomerAccountQuery>();
builder.Services.AddScoped<IGetCustomersAccountsQuery, GetCustomersAccountsQuery>();
builder.Services.AddScoped<IGetLastCostumerAccountQuery, GetLastCostumerAccountQuery>();
builder.Services.AddScoped<ICreateCustomerAccountCommand, CreateCustomerAccountCommand>();

builder.Services.AddAutoMapper(typeof(CustomerAccountProfile));

//builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCustomerAccountRequestValidator));

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
