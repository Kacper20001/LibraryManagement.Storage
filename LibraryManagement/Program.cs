using LibraryManagement.Extensions;

namespace LibraryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Dodanie us³ug bibliotecznych
            builder.Services.AddLibraryManagementServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Map routes
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Clients}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "loans",
                pattern: "loans/{action=Index}/{clientId?}",
                defaults: new { controller = "Loans", action = "Index" });

            app.MapControllerRoute(
                name: "clients",
                pattern: "clients/{action=Index}/{id?}",
                defaults: new { controller = "Clients", action = "Index" });

            app.MapControllerRoute(
              name: "books",
             pattern: "Books/{action=Index}/{id?}",
             defaults: new { controller = "Books", action = "Index" });

            app.Run();
        }
    }
}
