using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MinApiReactTsFoodOrder.Data;
using MinApiReactTsFoodOrder.Extensions;
using MinApiReactTsFoodOrder.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod() .AllowAnyHeader();
}));

builder.Services.AddEndpointsApiExplorer();
//add swagger from WebApplicationBuilderExtensions
builder.Services.AddSwagger();

builder.Services.AddProblemDetails();
builder.Services.AddApiVersioning();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add DB Contexts
// Move the connection string to user secrets for a real app
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

builder.Services.AddScoped<TokenService, TokenService>();

// Support string to enum conversions
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
//
builder.Services.ConfigureHttpJsonOptions(opts =>
{
    // opts.SerializerOptions.IncludeFields = true;
    opts.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.RegisterAuthentication();

// builder.Services.AddAutoMapper(typeof(FoodProfiles));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("MyPolicy");
}
app.UseCors("MyPolicy");

app.UseHttpsRedirection();
app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();