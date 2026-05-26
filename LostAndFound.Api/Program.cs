var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
<<<<<<< HEAD
=======

builder.Services.AddControllers();
>>>>>>> 4861a71 (added webapi to solution for future expansion of project.)
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

<<<<<<< HEAD
=======
app.UseAuthorization();

app.MapControllers();

>>>>>>> 4861a71 (added webapi to solution for future expansion of project.)
app.Run();
