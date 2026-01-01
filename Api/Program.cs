using Application.Repository.BidRepo;
using Application.Repository.EvaluationRepo;
using Application.Repository.TenderRepo;
using Application.Service.BidService;
using Application.Service.EvaluationService;
using Application.Service.TenderService;
using Application.UnitOfWork;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    "Data Source=.\\SQLEXPRESS02;Initial Catalog=TenderManagementSystem;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
            );


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITenderService, TenderService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IEvaluationService, EvaluationService>();

builder.Services.AddScoped<ITenderRepository, TenderRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();


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