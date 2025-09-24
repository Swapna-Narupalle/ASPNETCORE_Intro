using Introduction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//you are creating the instance   IEmployeeV2Reposiotry   = new InMemoryEmployeeRepository( i am the boss angularcorecomipler
builder.Services.AddScoped<IEmployeeV2Reposiotry, InMemoryEmployeeRepository>();

builder.Services.AddCors((cors) =>
{
    cors.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.WithOrigins("http://localhost:4200").
        AllowAnyHeader().
        AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowLocalhost4200");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
