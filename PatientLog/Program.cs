using PatientLog.Data.Repositories.Abstract;
using PatientLog.Data.Repositories.Concrete;
using PatientLog.Service.Abstract;
using PatientLog.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repository
builder.Services.AddScoped<IAdminRepository, AdminRepository>();


//Business Services
builder.Services.AddScoped<IAdminService, AdminService>();



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
