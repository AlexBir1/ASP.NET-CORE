using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.DAL.Repositories;
using WebHostel.DAL;
using Microsoft.EntityFrameworkCore;
using WebHostel.Services.Implements;

namespace WebHostel
{
    public partial class Startup
    {
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<BookingRepository>();
            services.AddScoped<BookingService>();

            services.AddScoped<CafeRepository>();
            services.AddScoped<CafeService>();

            services.AddScoped<CarsRepository>();
            services.AddScoped<CarsService>();

            services.AddScoped<ChecksRepository>();
            services.AddScoped<ChecksService>();

            services.AddScoped<Chosen_servicesRepository>();
            services.AddScoped<ChosenServicesService>();

            services.AddScoped<CustomersRepository>();
            services.AddScoped<CustomersService>();

            services.AddScoped<DishesRepository>();
            services.AddScoped<DishesService>();

            services.AddScoped<DocumentationRepository>();
            services.AddScoped<DocumentationService>();

            services.AddScoped<HostelRepository>();
            services.AddScoped<HostelService>();

            services.AddScoped<OrdersRepository>();
            services.AddScoped<OrdersService>();

            services.AddScoped<RoomsRepository>();
            services.AddScoped<RoomsService>();

            services.AddScoped<Services_historyRepository>();
            services.AddScoped<Services_historyService>();

            services.AddScoped<ServicesRepository>();
            services.AddScoped<ServicesService>();

            services.AddScoped<Cafe_employeesRepository>();
            services.AddScoped<CafeEmployeesService>();

            services.AddScoped<EmployeesRepository>();
            services.AddScoped<EmployeesService>();

            services.AddScoped<Chosen_servicesRepository>();
            services.AddScoped<ChosenServicesService>();

            services.AddScoped<ProductsRepository>();
            services.AddScoped<ProductsService>();

            services.AddScoped<ManufactorerRepository>();
            services.AddScoped<ManufactorerService>();

            services.AddScoped<OrderedProductsRepository>();
            services.AddScoped<OrderedProductsService>();

            services.AddScoped<ChecksHistoryRepository>();
            services.AddScoped<ChecksHistoryService>();

            services.AddScoped<WirehouseRepository>();
            services.AddScoped<WirehouseService>();

            services.AddScoped<WordersRepository>();
            services.AddScoped<WordersService>();

            services.AddScoped<Wirehouse_employeesRepository>();
            services.AddScoped<WirehouseEmployeesService>();

            services.AddScoped<CafeRepository>();
            services.AddScoped<CafeService>();

            services.AddScoped<OrdersHistoryRepository>();
            services.AddScoped<OrdersHistoryService>();

            services.AddScoped<Employee_spendsRepository>();
            services.AddScoped<EmployeeSpendsService>();

            services.AddHostedService<ChecksHostedService>();
            services.AddHostedService<BookingHostedService>();

            services.AddHttpClient();
        }
    }
}
