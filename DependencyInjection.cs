using Application.Interfaces;
using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    /// <summary>
    /// Helper class/method for adding services to the dependency injectoin container
    /// </summary>
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IQueueRepository, QueueRepository>();
            services.AddScoped<ILetterRepository, LetterRepository>();
            services.AddScoped<ILetterTypeRepository, LetterTypeRepository>();
            services.AddScoped<IAdvanceNoticeRepository, AdvanceNoticeRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBBServiceEntities, BBServiceEntities>();
        }
    }
}
