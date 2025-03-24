using BancoOccidente.DataAccess.IRepositories;
using BancoOccidente.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.DataAccess
{
    public static class DataAccessLayerServicesRegistration
    {
        public static IServiceCollection ConfigureDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICreditCardStatementRepository, CreditCardStatementRepository>();
            services.AddScoped<ITransactionsReadRepository, TransactionsReadRepository>();
            services.AddScoped<ITransactionsWriteRepository, TransactionsWriteRepository>();
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();

            return services;
        }
    }
}
