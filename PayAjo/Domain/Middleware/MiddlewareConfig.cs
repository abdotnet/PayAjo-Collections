using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Hangfire;
using Swashbuckle.AspNetCore.Swagger;
using PayAjo.Data;
using Microsoft.EntityFrameworkCore;
using PayAjo.Data.Repository;
using System.Reflection;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Core.Services;
using Microsoft.AspNetCore.Identity;
using PayAjo.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PayAjo.Domain.Infrastucture.HangFire;

namespace PayAjo.Domain.Middleware
{
  public static class MiddlewareConfig
  {


    public static void AddDatabase(this IServiceCollection services, IConfiguration _config)
    {
      var connectionString = _config.GetConnectionString("conString");

      MigrateAssembly();

      services.AddDbContextPool<PayAjoContext>(options => options.UseSqlServer(connectionString));

      //Add Scoped  ShutterCart ... 
      services.AddScoped<DbContext, PayAjoContext>();
      services.AddTransient<IUserRepository, UserRepository>();

    }

    private static void MigrateAssembly()
    {
      var migrationAssembly = typeof(PayAjoContext).GetTypeInfo().Assembly.GetName().Name;
    }

    // Application Identity configuration ..
    public static void AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
    {
      services.AddIdentity<UserModel, string>(o =>
      {
              // configure identity options
              o.Password.RequireDigit = false;
        o.Password.RequireLowercase = false;
        o.Password.RequireUppercase = false;
        o.Password.RequireNonAlphanumeric = false;
        o.Password.RequiredLength = 6;
      }).AddDefaultTokenProviders();
    }

    public static void InitializeAppServices(this IServiceCollection services)
    {

      // User store & roles  .. 
      services.AddScoped<IUserStore<UserModel>, UserStore>();
      services.AddScoped<IRoleStore<string>, RoleStore>();

      // Add transient app services  items

      services.AddTransient<IMerchantService, MerchantService>();
      services.AddTransient<ICustomerService, CustomerService>();
      services.AddTransient<ICollectionService, CollectionService>();
      services.AddTransient<ITransactionService, TransactionService>();
      services.AddTransient<IWithdrawalService, WithdrawalService>();
      services.AddTransient<ISettingService, SettingService>();
      services.AddTransient<IHangFireService, HangFireService>();
      services.AddTransient<INotificationService, NotificationService>();
      services.AddTransient<IReportingService, ReportingService>();
      services.AddTransient<ISettlementService, SettlementService>();

    }

    public static void HangFireService(this IServiceCollection services, IConfiguration _config)
    {
      services.AddHangfire(_ => _.UseSqlServerStorage(_config.GetConnectionString("conString")));

    }
    public static void Initializedb(this IApplicationBuilder app, IHostingEnvironment env)
    {

      if (env.IsDevelopment())
      {
        //using (var scope = app.ApplicationServices.CreateScope())
        //{
        //  var seeder = scope.ServiceProvider.GetService<ShutterCartSeeder>();

        //  seeder.Seed().Wait();
        //}
      }


    }

    public static void ConfigureServices(this IServiceCollection services)
    {
      services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
    }


    /// <summary>
    /// Configure Jwt authentication service  .. 
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureJwtAuthService(this IServiceCollection services, IConfiguration _config, IHostingEnvironment _env)
    {


      var keyByteArray = Encoding.ASCII.GetBytes(_config["Tokens:key"]);
      var signingKey = new SymmetricSecurityKey(keyByteArray);

      var tokenValidationParameters = new TokenValidationParameters
      {
        // The signing key must match!  
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,

        // Validate the JWT Issuer (iss) claim  
        ValidateIssuer = true,
        ValidIssuer = _config["Tokens:Issuer"],

        // Validate the JWT Audience (aud) claim  
        ValidateAudience = true,
        ValidAudience = _config["Tokens:Audience"],

        // Validate the token expiry  
        ValidateLifetime = LifetimeValidator(int.Parse(_config["Tokens:AccessExpireMinutes"])),

        ClockSkew = TimeSpan.Zero
      };

      //add permission enable cross-origin requests (CORS) from angular
      var corsBuilder = new CorsPolicyBuilder();
      corsBuilder.AllowAnyHeader();
      corsBuilder.AllowAnyMethod();
      corsBuilder.AllowAnyOrigin();
      corsBuilder.AllowCredentials();

      services.AddCors(options =>
      {
        options.AddPolicy("AllowAll", corsBuilder.Build());

      });


      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(o =>
      {
        o.TokenValidationParameters = tokenValidationParameters;
      });

      services.AddAuthorization(auth =>
      {
        auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                  .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                  .RequireAuthenticatedUser().Build());
      });

      services.AddAutoMapper();


      services.AddSingleton<IHostingEnvironment>(_env);
      services.AddSingleton<IConfiguration>(_config);

      // Register app services  ..
      services.InitializeAppServices();
      //services.AddMvc();
      services.AddMvc(opt =>
      {
              // opt.ModelBinderProviders.Insert(0, new UserModelBinderProvider());

              if (_env.IsProduction() && _config["DisableSSL"] != "true")
        {
                // opt.Filters.Add(new RequireHttpsAttribute());
              }

      }).AddJsonOptions(opt =>
      {
        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
        opt.SerializerSettings.SerializationBinder = new DefaultSerializationBinder();
        opt.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

      });
    }

    public static void Logger(this IApplicationBuilder app, ILoggerFactory loggerFactory, IConfiguration _config)
    {
      //loggerFactory.AddConsole(_config.GetSection("Logging"));
      //loggerFactory.AddDebug();
      ////FileLoggerExtensions
      //loggerFactory.AddFile("logs/PayAjo-{Date}.txt");
    }

    public static void ActivateReactMvc(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }

      //app.UserCorsMiddleWare();

      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseAuthentication();


      // app.UseMvc();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");

        routes.MapSpaFallbackRoute(
                  name: "spa-fallback",
                  defaults: new { controller = "Home", action = "Index" });
      });

    }
    private static bool LifetimeValidator(int expires)
    {
      if (expires > 0)
      {
        if (DateTime.UtcNow.Minute < expires) return true;
      }
      return false;
    }


  }

  public static class CustomMiddlewareExtensions
  {
    public static IApplicationBuilder UseCustomHanlderMiddleware
                                  (this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<RefreshTokenProviderMiddleware>();
    }
  }
}
