using Microsoft.AspNetCore.Components.Forms;
using Microsoft.OpenApi.Models;
using Presentation;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;
using Application.Handler;
using MediatR;
using System.Reflection;

string cors = "CorsApp";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();


        });
});



ConfigApp.Config(builder.Services, builder.Configuration.GetConnectionString("DBContext"));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();


}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(config =>
{

    config.RegisterServicesFromAssemblies(typeof(RegisterCommandHandler).Assembly);
});


builder.Services.AddControllersWithViews().
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "SerialManagementApi"
    });
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();


//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger(); 
//    app.UseSwaggerUI();
//}
if (builder.Configuration.GetValue<bool>("EnvironmentMode:Development"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocExpansion(DocExpansion.None);
    });
}

app.UseSwaggerUI(c =>
{
    c.DocExpansion(DocExpansion.None);
});

app.UseCors(cors);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.UseAuthorization();
app.MapControllers();

app.Run();


public partial class Program
{

}