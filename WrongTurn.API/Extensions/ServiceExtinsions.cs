using WrongTurn.API.Services;

namespace WrongTurn.API.Extensions
{
    public static class ServiceExtinsions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<PlayerStateService>();
            return services;
        }
    }
}
