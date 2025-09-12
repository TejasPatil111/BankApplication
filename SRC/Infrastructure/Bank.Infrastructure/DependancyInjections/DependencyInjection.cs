using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Interfaces;
using Bank.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Infrastructure.DependancyInjection
{
    public static class DependencyInjection
    {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BankDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ICustomerRepsitory, CustomerRepositories>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepositories>();
            services.AddScoped<ILedgerRepository, LeddgerRepository>();
            services.AddScoped<IMoneyRepository, MoneyRepository>();
            return services;
        }
    }
}
