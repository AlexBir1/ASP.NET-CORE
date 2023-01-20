using elfbar_shop.DAL.Services.Implements;
using elfbar_shop.DAL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace elfbar_shop
{
    public partial class Startup
    {
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IProfilesService, ProfilesService>();
            services.AddScoped<ISell_InfoService, Sell_InfoService>();
            services.AddScoped<ISpendsService, SpendsService>();
            

            services.AddScoped<ITypesService, TypesService>();
            services.AddScoped<IOrderHistoryService, OrderHistoryService>();
            services.AddScoped<IWirehousesService, WirehousesService>();
            services.AddScoped<ILaughService, LaughService>();

            services.AddDetection();
            services.AddHttpClient();
        }
    }
}
