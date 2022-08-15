using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories;
using IMDB.Project.EF.Repositories.Interfaces;
using IMDB.Project.Services;
using IMDB.Project.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("iMDBContext");
builder.Services.AddDbContext<IMDBContext>(options => {
    options.UseSqlServer(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped <IActorRepository, ActorRepository>();
builder.Services.AddScoped <IProducerRepository, ProducerRepository>();
builder.Services.AddScoped <IPosterRepository, PosterRepository>();
builder.Services.AddScoped <IActorMovieMappingsRepository, ActorMovieMappingsRepository>();
builder.Services.AddScoped <IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped <IActorService, ActorService>();
builder.Services.AddScoped <IProducerService, ProducerService>();
builder.Services.AddScoped <IPosterService, PosterService>();
builder.Services.AddScoped <IActorMovieMappingsService, ActorMovieMappingsService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
