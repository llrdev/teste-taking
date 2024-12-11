using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISaleRepository, InMemorySaleRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGet("/api/sales", async (ISaleRepository saleRepository) =>
{
    var sales = await saleRepository.GetAllAsync();
    return Results.Ok(sales.Select(s => new SaleDto { Id = s.Id, SaleDate = s.SaleDate, SaleAmount = s.SaleAmount }));
});

app.MapGet("/api/sales/{id}", async (int id, ISaleRepository saleRepository) =>
{
    var sale = await saleRepository.GetByIdAsync(id);
    return sale is not null
        ? Results.Ok(new SaleDto { Id = sale.Id, SaleDate = sale.SaleDate, SaleAmount = sale.SaleAmount })
        : Results.NotFound();
});

app.MapPost("/api/sales", async (SaleDto saleDto, ISaleRepository saleRepository) =>
{
    var sale = new Sale { SaleDate = saleDto.SaleDate, SaleAmount = saleDto.SaleAmount };
    await saleRepository.CreateAsync(sale);
    return Results.Created($"/api/sales/{sale.Id}", new SaleDto { Id = sale.Id, SaleDate = sale.SaleDate, SaleAmount = sale.SaleAmount });
});

app.MapPut("/api/sales/{id}", async (int id, SaleDto saleDto, ISaleRepository saleRepository) =>
{
    var sale = new Sale { Id = id, SaleDate = saleDto.SaleDate, SaleAmount = saleDto.SaleAmount };
    await saleRepository.UpdateAsync(sale);
    return Results.NoContent();
});

app.MapDelete("/api/sales/{id}", async (int id, ISaleRepository saleRepository) =>
{
    await saleRepository.DeleteAsync(id);
    return Results.NoContent();
});

app.Run();