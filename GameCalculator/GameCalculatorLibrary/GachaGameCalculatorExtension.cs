using GameCalculatorLibrary.BLL;
using GameCalculatorLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCalculatorLibrary
{
    public static class GachaGameCalculatorExtension
    {
        public static void GachaGameCalculatorDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<GachaGameCalculatorContext>(options);
            services.AddTransient<GameServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<GachaGameCalculatorContext>();
                return new GameServices(context);
            });
        }

    }
}
