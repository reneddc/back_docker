using AquiEstoy_MongoDB.Data.Repository;
using AquiEstoy_MongoDB.Services;


var builder = WebApplication.CreateBuilder(args);



//CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); });
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddTransient<IAquiEstoyCollection, AquiEstoyCollection>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPetService, PetService>();
builder.Services.AddTransient<ILostPetPostService, LostPetPostService>();
builder.Services.AddTransient<IFoundPetPostService, FoundPetPostService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); });

app.UseAuthorization();

app.MapControllers();

app.Run();
