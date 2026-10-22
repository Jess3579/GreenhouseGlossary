using GreenhouseGlossary.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenhouseGlossary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<PlantContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("PlantContext")
                    ?? throw new InvalidOperationException(
                        "Connection string 'PlantContext' not found.")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
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
}
