using Microsoft.EntityFrameworkCore;
using PatientLog.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=localhost, 1433;Database=PatientLogDb;User ID=SA;Password=Sifre0134;TrustServerCertificate=True");
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();