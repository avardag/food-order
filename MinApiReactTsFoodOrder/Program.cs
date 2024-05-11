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
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddProblemDetails();
builder.Services.AddApiVersioning();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add DB Contexts
// Move the connection string to user secrets for a real app
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=devpass"));

builder.Services.AddScoped<TokenService, TokenService>();

// Support string to enum conversions
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


// Specify identity requirements
// Must be added before .AddAuthentication otherwise a 404 is thrown on authorized endpoints
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//add Authentication of type JwtBearer
// These will eventually be moved to a secrets file, but for alpha development appsettings is fine
var validIssuer = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidIssuer");
var validAudience = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidAudience");
var symmetricSecurityKey = builder.Configuration.GetValue<string>("JwtTokenSettings:SymmetricSecurityKey");

builder.Services.AddAuthentication(options => {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;})
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = validIssuer,
            ValidAudience = validAudience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(symmetricSecurityKey)
            ),
        };
    });

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

app.MapGet("/api/food", () =>
{
    //load json from data.json
    var foodJson = File.ReadAllText("data.json");
    var food = JsonSerializer.Deserialize<List<Food>>(foodJson, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
    //send food to client
    return food;
});

app.MapGet("/api/food/search/{searchTerm}", ([FromRoute]string searchTerm) =>
{
    //load json from data.json
    var foodJson = File.ReadAllText("data.json");
    var foods = JsonSerializer.Deserialize<List<Food>>(foodJson, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
    //filter foods list to include only those that match searchterm
    var filteredFoods = foods?.Where(food => food.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
    //send filtered food to client
    return filteredFoods;
});
//route to return tags
app.MapGet("api/tags", () =>
{
    //load json from tags.json
    var tagsJson = File.ReadAllText("tags.json");
    var tags = JsonSerializer.Deserialize<List<TagToReturnDto>>(tagsJson,
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    //send tags to client
    return tags;
});

//route to return food by tag
app.MapGet("/api/food/tag/{tag}", ([FromRoute] string tag) =>
{
    //load json from data.json
    var foodJson = File.ReadAllText("data.json");
    var foods = JsonSerializer.Deserialize<List<Food>>(foodJson,
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    //filter foods list to include only those that match tag
    var filteredFoods = foods?.Where(food => food.Tags.Contains(tag)).ToList();
    //send filtered food to client
    return filteredFoods;
});
//route to return food by id
app.MapGet("/api/food/{foodId:int}", ([FromRoute] int foodId) =>
{
    //load json from data.json
    var foodJson = File.ReadAllText("data.json");
    var foods = JsonSerializer.Deserialize<List<Food>>(foodJson,
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    //filter foods list to include only those that match id
    var filteredFoods = foods?.Where(food => food.Id == foodId).ToList();
    //send filtered food to client
    return filteredFoods;
});

app.Run();