using Microsoft.EntityFrameworkCore;
using PatientLog.Data.Contexts;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Data.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repository
builder.Services.AddScoped<IAdminRepository, AdminRepository>();


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
