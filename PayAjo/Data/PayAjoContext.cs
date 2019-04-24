using Microsoft.EntityFrameworkCore;
using PayAjo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data
{
  public class PayAjoContext : DbContext
  {
    public PayAjoContext(DbContextOptions<PayAjoContext> options) : base(options)
    {
      new DbContextOptionsBuilder().EnableSensitiveDataLogging(true);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<SocialLogin> SocialLogin { get; set; }
    public DbSet<Claim> Claims { get; set; }
    public DbSet<Transaction> Transaction { get; set; }
    public DbSet<Notification> Notification { get; set; }
    public DbSet<Permission> Permission { get; set; }
    public DbSet<RolePermission> RolePermission { get; set; }
    public DbSet<Setting> Setting { get; set; }
    public DbSet<AuditTrail> AuditTrail { get; set; }
    public DbSet<MerchantWalletBalance> MerchantWalletBalance { get; set; }
    //public DbSet<AdminSmsWallet> AdminSmsWallet { get; set; }
    public DbSet<Merchant> Merchant { get; set; }
    public DbSet<Collection> Collection { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<CustomerBalance> CustomerBalance { get; set; }
    public DbSet<MerchantBalance> MerchantBalance { get; set; }
    public DbSet<MerchantBalanceSetting> MerchantBalanceSetting { get; set; }
    public DbSet<Withdrawal> Withdrawal { get; set; }
    public DbSet<MerchantAgentBalance> MerchantAgentBalance { get; set; }
    public DbSet<TransactionLog> TransactionLog { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

      //modelBuilder.Entity<Customer>().HasIndex(u => u.CustomerCode).IsUnique();
      //modelBuilder.Entity<User>().HasIndex(u => u.MasterCode).IsUnique();

      // modelBuilder.Entity<Customer>().HasIndex(u => u.Mobile).IsUnique();
      //modelBuilder.Entity<Merchant>().HasIndex(u => u.BusinessMobile).IsUnique();
      //modelBuilder.Entity<User>().has

      // PayAjoSeeder.Seed(_context);
      base.OnModelCreating(modelBuilder);
    }
  }
}
