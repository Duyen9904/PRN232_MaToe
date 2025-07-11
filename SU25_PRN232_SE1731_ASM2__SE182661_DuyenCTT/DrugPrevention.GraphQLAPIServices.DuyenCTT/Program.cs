using DrugPrevention.GraphQLAPIServices.DuyenCTT.GraphQLs;
using DrugPrevention.Services.DuyenCTT;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer()
    .AddQueryType<CourseEnrollmentDuyenCTTQueries>()
    .AddMutationType<Mutation>()
    .BindRuntimeType<DateTime, DateTimeType>();
builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting().UseEndpoints(endpoints => { endpoints.MapGraphQL(); });

app.UseAuthorization();

app.MapControllers();

app.Run();
