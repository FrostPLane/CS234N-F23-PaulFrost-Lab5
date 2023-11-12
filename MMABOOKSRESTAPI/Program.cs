using Google.Protobuf.WellKnownTypes;
using Humanizer;
using MMABooksEFClasses.MODELS;

var builder = WebApplication.CreateBuilder(args);

// ADD CORS POLICY - IN A PRODUCTION APP LOCK THIS DOWN!
builder.Services.AddCors(OPTIONS => {
    OPTIONS.AddDefaultPolicy(
builder => { builder.AllowAnyOrigin().WithMethods("POST", "PUT", "DELETE", "GET", "OPTIONS").AllowAnyHeader();
});
});
// ADDING THE DBCONTEXT TO THE SERVICE
builder.Services.AddDbContext<MMABOOKSCONTEXT>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// IN A PRODUCTION APP YOU WOULD WANT TO TURN THIS BACK ON!
// APP.USEHTTPSREDIRECTION();

// ENABLES THE CORS POLICY
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
