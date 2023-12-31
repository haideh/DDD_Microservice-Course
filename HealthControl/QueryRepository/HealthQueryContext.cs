using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Model.User;
using QueryRepository.Mapping;
using Contract.ViewModel.User;
using Contract.ViewModel.Order.Kit;
using Contract.ViewModel.Order.KitRules;
using Contract.ViewModel.Order.Discount;
using Contract.ViewModel.Order.Cart;

namespace QueryRepository
{

    public class HealthQueryContext : DbContext
    {
        public HealthQueryContext(DbContextOptions<HealthQueryContext> options) : base(options)
        {

        }
        #region tables

        public DbSet<UserDto> Users { get; set; }
        public DbSet<KitDto> Kits { get; set; }
        public DbSet<CountryKitDto> CountryKits { get; set; }
        public DbSet<KitRulesDto> KitRules { get; set; }
        public DbSet<DiscountDto> Discounts { get; set; }
        public DbSet<CartDto> Carts { get; set; }
        public DbSet<CartItemDto> CartItems { get; set; }
     
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            //modelBuilder.Entity<UserDto>().OwnsOne(x => x.Addresses);

            base.OnModelCreating(modelBuilder);
        }

    }
}
