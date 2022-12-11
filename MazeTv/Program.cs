using MazeTv.Extensions;
using MazeTV.Persistence;
using MazteTv.Service;
//using MazteTv.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.


services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddSingleton<MazeTvConfiguration>(config =>
{
    var configration = config.GetService<IConfiguration>();

    return new MazeTvConfiguration(configration["MazeTvApiRoot"]);
});

services.AddHttpClient<IMazeTvService, MazeTvService>((provider, client) =>
{
    var config = provider.GetService<MazeTvConfiguration>();
    client.BaseAddress = new Uri(config.BaseUrl);
});

services.AddScoped<IFetchService, FetchService>();


services.AddDbContext<AppDbContext>(opt =>
{
    var connStr = builder.Configuration.GetConnectionString("AppDbContext");
    opt.UseSqlite(connStr);
   
},ServiceLifetime.Transient);

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

await app.Migration();
app.Fetch();

app.Run();


