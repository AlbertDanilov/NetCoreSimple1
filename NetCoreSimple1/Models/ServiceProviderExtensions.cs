using NetCoreSimple1.Interfaces;

namespace NetCoreSimple1.Models
{
    public static class ServiceProviderExtensions
    {
        public static void AddTimeService(this IServiceCollection services)
        {
            services.AddTransient<ITimeService, LongTimeService>();
        }
    }
}
