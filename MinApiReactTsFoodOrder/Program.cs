using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinApiReactTsFoodOrder.Data;
using MinApiReactTsFoodOrder.DTOs;
using MinApiReactTsFoodOrder.Entities;
using MinApiReactTsFoodOrder.Extensions;
using MinApiReactTsFoodOrder.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod() .AllowAnyHeader();
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

builder.RegisterAuthentication();

// // Specify identity requirements
// // Must be added before .AddAuthentication otherwise a 404 is thrown on authorized endpoints
// builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
//     {
//         options.Password.RequireDigit = true;
//         options.Password.RequireLowercase = true;
//         options.Password.RequireUppercase = true;
//         options.Password.RequireNonAlphanumeric = false;
//         options.Password.RequiredLength = 8;
//         options.SignIn.RequireConfirmedAccount = false;
//         options.User.RequireUniqueEmail = true;
//     })
//     .AddEntityFrameworkStores<ApplicationDbContext>();
//
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme =
//         options.DefaultChallengeScheme =
//             options.DefaultForbidScheme =
//                 options.DefaultScheme =
//                     options.DefaultSignInScheme =
//                         options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidIssuer = builder.Configuration["JWT:Issuer"],
//         ValidateAudience = true,
//         ValidAudience = builder.Configuration["JWT:Audience"],
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(
//             System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
//         )
//     };
// });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("MyPolicy");
}

app.UseHttpsRedirection();
app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// app.MapGet("/api/food", () =>
// {
//     //load json from data.json
//     var foodJson = File.ReadAllText("data.json");
//     var food = JsonSerializer.Deserialize<List<Food>>(foodJson, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
//     //send food to client
//     return food;
// });

// app.MapGet("/api/food/search/{searchTerm}", ([FromRoute]string searchTerm) =>
// {
//     //load json from data.json
//     var foodJson = File.ReadAllText("data.json");
//     var foods = JsonSerializer.Deserialize<List<Food>>(foodJson, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
//     //filter foods list to include only those that match searchterm
//     var filteredFoods = foods?.Where(food => food.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
//     //send filtered food to client
//     return filteredFoods;
// });
// //route to return tags
// app.MapGet("api/tags", () =>
// {
//     //load json from tags.json
//     var tagsJson = File.ReadAllText("tags.json");
//     var tags = JsonSerializer.Deserialize<List<TagToReturnDto>>(tagsJson,
//         new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
//     //send tags to client
//     return tags;
// });
//
// //route to return food by tag
// app.MapGet("/api/food/tag/{tag}", ([FromRoute] string tag) =>
// {
//     //load json from data.json
//     var foodJson = File.ReadAllText("data.json");
//     var foods = JsonSerializer.Deserialize<List<Food>>(foodJson,
//         new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
//     //filter foods list to include only those that match tag
//     var filteredFoods = foods?.Where(food => food.Tags.Contains(tag)).ToList();
//     //send filtered food to client
//     return filteredFoods;
// });
// //route to return food by id
// app.MapGet("/api/food/{foodId:int}", ([FromRoute] int foodId) =>
// {
//     //load json from data.json
//     var foodJson = File.ReadAllText("data.json");
//     var foods = JsonSerializer.Deserialize<List<Food>>(foodJson,
//         new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
//     //filter foods list to include only those that match id
//     var filteredFoods = foods?.Where(food => food.Id == foodId).ToList();
//     //send filtered food to client
//     return filteredFoods;
// });

app.Run();