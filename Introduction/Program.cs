using Introduction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors((cors) =>
{
    cors.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.WithOrigins("http://localhost:4200").
        AllowAnyHeader().
        AllowAnyMethod();
    });
});

//https://localhost:7233/api/Employees/GetEmpName


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowLocalhost4200");


//Multiple middlewares in future
//app.UseMiddleware<HTTPContextMiddleware>();
//logging
//excption
//autthenication
app.UseHttpContextDemo();
app.UseLoggingContextDemo();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
