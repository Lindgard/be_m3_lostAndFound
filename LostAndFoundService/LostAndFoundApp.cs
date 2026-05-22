namespace LostAndFoundService;

public class LostAndFoundApp
{
    public static void Main(string[], args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        var app = builder.build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.useDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}