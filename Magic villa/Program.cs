using Magic_villa;
using Magic_villa.DbContexts;
using Magic_villa.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().
    WriteTo.File("logs/log", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IMagicVillaRepository, MagicVillaRepository>();
builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
builder.Host.UseSerilog();
builder.Services.AddDbContext<MagicVillaDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MagicVilla")));
builder.Services.AddControllers(
    option => option.ReturnHttpNotAcceptable = true
    )
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();
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
