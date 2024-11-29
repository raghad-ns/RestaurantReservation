using Microsoft.Extensions.Options;
using RestaurantReservation.Configuration.Options;
using RestaurantReservation.Db;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservationWeb;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        // Add services to the container.
        builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(DatabaseOptions.Database));

        builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
        {
            var serviceProvider = builder.Services.BuildServiceProvider();
            var databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
            options.UseSqlServer(databaseOptions.ConnectionString);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}