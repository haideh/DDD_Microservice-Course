using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Model.User;
using Repository.Mapping;
using Domain.Model.Order.Kit;
using Domain.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using Repository.Converter;

namespace Repository
{

    public class HealthContext : DbContext
    {
        public HealthContext(DbContextOptions<HealthContext> options) : base(options)
        {

        }
        #region tables

        public DbSet<User> Users { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<KitRules> KitRules { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<Country>().HaveConversion<CountryConverter>();
            configurationBuilder.Properties<Address>().HaveConversion<AddressConverter>();
        }

    }

    
}
