using StoredProcedure.Configuration;
using StoredProcedure.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetSection(AppSettings.SectionName).Bind(AppSettings.Settings);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
