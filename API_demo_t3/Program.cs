using API_demo_t3.Data;
using API_demo_t3.Repositories.Implements;
using API_demo_t3.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
        options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IDataImportExportRepository, DataImportExportRepository>();

builder.Services.AddDbContext<DbContextBMW>(options =>
{
    var connecttionString = builder.Configuration.GetConnectionString("DbBMW");
    options.UseSqlServer(connecttionString);
});

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
