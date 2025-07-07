using DrugPrevention.Services.DuyenCTT;
using DrugPrevention.SoapApiServices.DuyenCTT.SoapServices;
using SoapCore;
using System.ServiceModel.Channels;
using SoapCore.Extensibility;
using DrugPrevention.SoapApiServices.DuyenCTT;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
builder.Services.AddScoped<ICourseEnrollmentDuyenCTTSoapService, CourseEnrollmentDuyenCTTSoapService>();
builder.Services.AddScoped<IAccountSoapService, AccountSoapService>();
builder.Services.AddSingleton<IFaultExceptionTransformer, CustomFaultExceptionTransformer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSoapEndpoint<ICourseEnrollmentDuyenCTTSoapService>("/CourseEnrollmentDuyenCTTSoapService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<IAccountSoapService>("/AccountSoapService.asmx", new SoapEncoderOptions());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
