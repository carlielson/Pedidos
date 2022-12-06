using Microsoft.EntityFrameworkCore;
using Pedidos.Repositories;
using Pedidos.Domain.Interfaces;
using Pedidos.Repository.Context;
using Pedidos.Seed;
using Pedidos.Sevices;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<PedidosContext>(opt => opt.UseInMemoryDatabase(databaseName: "PedidosDb"));

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IItemPedidoService, ItemPedidoService>();

builder.Services.AddTransient<DataSeeder>();


// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

using (var scope = app.Services.CreateScope())
try
{
    var scopedContext = scope.ServiceProvider.GetService<DataSeeder>();
    scopedContext.Seed();
    // DataSeeder.Initialize(scopedContext);
}
catch
{
    throw;
}

        app.UseHttpsRedirection();

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

app.UseAuthorization();

app.MapControllers();

app.Run();
