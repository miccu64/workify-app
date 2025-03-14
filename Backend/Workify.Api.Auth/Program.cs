using Workify.Utils.Config;
using Workify.Utils.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.CommonApiInitialization<CommonConfig>();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.CommonApiInitialization();

app.MapControllers();

app.Run();
