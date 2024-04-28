using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MinApiReactTsFoodOrder.DTOs;
using MinApiReactTsFoodOrder.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod() .AllowAnyHeader();
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("MyPolicy");
}

app.UseHttpsRedirection();

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