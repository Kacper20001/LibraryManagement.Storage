using Microsoft.Extensions.DependencyInjection;
using LibraryManagement.Storage.Repository;
using LibraryManagement.Storage;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Extensions
{
    public static class LibraryManagementExtension
    {
        public static IServiceCollection AddLibraryManagementServices(this IServiceCollection serviceCollection)
        {
            // Rejestracja repozytorium
            serviceCollection.AddScoped<ILibraryRepository, LibraryRepository>();

            // Rejestracja DbContext z konfiguracją bazy danych
            serviceCollection.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer("server=DESKTOP-3QM33ET;database=LibraryDatabase;Trusted_Connection=True;TrustServerCertificate=True")); 

            return serviceCollection;
        }
    }
}
