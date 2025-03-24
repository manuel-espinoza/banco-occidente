using BancoOccidente.Service.IServices;
using BancoOccidente.Service.Mappings;
using BancoOccidente.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service
{
    public static class ServiceLayerServicesRegistration
    {
        public static IServiceCollection ConfigureServiceLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddAutoMapper(typeof(CustomerProfile));
            services.AddScoped<ICreditCardStatementService, CreditCardStatementService>();
            services.AddAutoMapper(typeof(CreditCardStatementPurchasesProfile));
            services.AddScoped<ITransactionsReadService, TransactionsReadService>();
            services.AddScoped<ICreditCardService, CreditCardService>();
            services.AddAutoMapper(typeof(CreditCardProfile));
            services.AddAutoMapper(typeof(TransactionProfile));
            services.AddScoped<ITransactionsWriteService, TransactionsWriteService>();

            return services;
        }
    }
}
