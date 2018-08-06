using HBSIS.Livraria.Application.Services;
using HBSIS.Livraria.Infra.Dal.Interfaces;
using HBSIS.Livraria.Application.Interfaces;
using HBSIS.Livraria.Infra.Dal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HBSIS.Livraria.Infra.CrossCutting.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
