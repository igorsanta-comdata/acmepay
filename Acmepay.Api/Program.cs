using Acmepay.Api.Common.Errors;
using Acmepay.Api.Middleware;
using Acmepay.Application;
using AcmepayAPI.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .Addinfrastructure();

    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, AcmepayProblemDetailsFactory>();
}

var connectionString = builder.Configuration.GetConnectionString("AcmepayDatabaseConnectionString");
builder.Services.AddDbContext<ApiContext>(options => options.UseSqlServer(connectionString));
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Acmepay.Api", Version = "v1" });

    //Set the comments path for the Swagger JSON an UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();


