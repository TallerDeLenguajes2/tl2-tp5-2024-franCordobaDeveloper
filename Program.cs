using tl2_tp5_2024_franCordobaDeveloper.Repositorios;
using tl2_tp5_2024_franCordobaDeveloper.Repositorios.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductoRepository>(provider =>
    new ProductosRepository("Data Source=db/Tienda.db;Cache=Shared"));
builder.Services.AddScoped<IPresupuestoRepository>(provider =>
    new PresupuestoRepository("Data Source=db/Tienda.db;Cache=Shared"));


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
