using PokeBL;
using PokeDL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository>(repo => new SQLRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IStoreFrontRepo>(repo => new SQLStoreFrontRepo(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IInventoryRepo>(repo => new SQLInventory(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IOrderRepo>(repo => new SQLOrderRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IProductRepo>(repo => new SQLProductRepository(builder.Configuration.GetConnectionString("Reference2DB")));

builder.Services.AddScoped<IPokemonBL, CustomerBL>();
builder.Services.AddScoped<IStoreFrontBL, StoreFrontBL>();
builder.Services.AddScoped<IInventoryBL, InventoryBL>();
builder.Services.AddScoped<IOrderBL, OrderBL>();
builder.Services.AddScoped<IProductBL, ProductBL>();
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
