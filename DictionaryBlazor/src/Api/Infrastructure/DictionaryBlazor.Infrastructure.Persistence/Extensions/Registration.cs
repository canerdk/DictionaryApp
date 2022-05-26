using DictionaryBlazor.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryBlazor.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DictionaryBlazorContext>(conf =>
            {
                var connectionString = configuration["DictionaryDbConnectionString"].ToString();
                conf.UseSqlServer(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            var seedData = new SeedData();
            seedData.SeedAsync(configuration).GetAwaiter().GetResult();

            return services;
        }
    }
}
