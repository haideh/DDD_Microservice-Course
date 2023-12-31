using Application.OrderService;
using Application.UserServices;
using Contract;
using Contract.Query;
using Contract.Services;
using Domain.DomainService;
using Domain.IRepository;
using DomainService;
using Microsoft.EntityFrameworkCore;
using QueryRepository;
using QueryRepository.Repository;
using Repository;
using Repository.Repositories;

namespace Presentation
{
    public class ConfigApp
    {
        public static void Config(IServiceCollection services, string connectionString)
        {

            #region Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IKitRepository, KitRepository>();
            services.AddTransient<IKitRulesRepository, KitRulesRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            #endregion

            #region Queries
            services.AddTransient<IUserQuery, UserQuery>();
            services.AddTransient<IKitQuery, KitQuery>();
            services.AddTransient<IDiscountQuery, DiscountQuery>();
            services.AddTransient<IKitRulesQuery, KitRulesQuery>();
            services.AddTransient<ICartQuery, CartQuery>();
            #endregion

            #region Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IKitService, KitService>();
            services.AddTransient<IKitRulesService, KitRulesService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<ICartService, CartService>();

            #endregion

            #region DomainServices
            services.AddTransient<IKitRulesDomainService, KitRulesDomainService>();
            services.AddTransient<IDiscountDomainService, DiscountDomainService>();
            #endregion


            services.AddTransient<IUnitOfWork, UnitOfWorkEf>();
            services.AddDbContext<HealthContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<HealthQueryContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        }
    }
}
