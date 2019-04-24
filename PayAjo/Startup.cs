using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayAjo.Data;
using PayAjo.Domain.Infrastucture.Exceptions;
using PayAjo.Domain.Infrastucture.HangFire;
using PayAjo.Domain.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace PayAjo
{
  /// <summary>
  /// Startup class
  /// </summary>
  public class Startup
  {
    /// <summary>
    /// Configuration 
    /// </summary>
    public IConfiguration _config { get; }
    /// <summary>
    /// Environment setup ..
    /// </summary>
    public IHostingEnvironment _env { get; }
    /// <summary>
    /// Startup constructor .. 
    /// </summary>
    /// <param name="config"></param>
    /// <param name="env"></param>


    public Startup(IConfiguration config, IHostingEnvironment env)
    {
      _config = config;
      _env = env;
    }

    /// <summary>
    ///  This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDatabase(_config);
      services.AddApplicationIdentity(_config);
      services.InitializeAppServices();

      // configure jwt auth service ..
      services.ConfigureJwtAuthService(_config, _env);

      // Background service ..
    //  services.HangFireService(_config);

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info
        {
          Version = "v1",
          Title = "Pay Ajo Portal",
          Description = "A simple platform for thrift collection",
          TermsOfService = "None",
          Contact = new Contact
          {
            Name = "PayAjo Inc.",
            Email = "info@payajo.com",
            Url = "http://payajo.com"
          },
          License = new License
          {
            Name = "Use under PayAjo Inc.",
            Url = "https://payajo.com"
          }
        });

        // Set the comments path for the Swagger JSON and UI.
        //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlFile = "swagger.xml";
        Debug.Write(xmlFile);
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });

      // configure services  ..
      services.ConfigureServices();

      //services.AddMvc();

    }

    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
    IConfiguration configuration, PayAjoContext _context, IHangFireService _hangFire)
    {

      // Initialize db  event  . 
      app.Initializedb(env);

      // log activities  .. 
      app.Logger(loggerFactory, configuration);



      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();

        //app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
        //{
        //  HotModuleReplacement = true
        //});
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      //app.UseAntiforgeryTokens();

      app.UseAuthentication();

      app.UseExceptionHandler(builder =>
      {
        builder.Run(
            async context =>
            {
              context.Response.ContentType = "application/json";
              var error = context.Features.Get<IExceptionHandlerFeature>();
              var result = context.Get(error.Error);
              await context.Response.WriteAsync(result);
            });
      });

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
      // specifying the Swagger JSON endpoint.

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pay Ajo portal");
        c.RoutePrefix = "swagger";
      });

      // context.Database.Migrate();

      // HangFire asp.net pipeline

      DashboardOptions opts = new DashboardOptions
      {
        Authorization = new[] { new CustomAuthorizeFilter() }
      };

     // app.UseHangfireServer();

    //  app.UseHangfireDashboard("/jobs", opts);

      //BackgroundJob.Schedule(() => _hangFire.ResetTechDateJob(),
      //  TimeSpan.FromMinutes(double.Parse(_config["System:TechDays"])));

      //BackgroundJob.Schedule(() => _hangFire.DebitTechCustomerBalanceOnIsChargeableJob(),
      //  TimeSpan.FromMinutes(double.Parse(_config["System:SmsDays"])));

      // RecurringJob.AddOrUpdate(() => _hangFire.SendSmsHangFireNotification(), Cron.Daily);

      // RecurringJob.AddOrUpdate(() => _hangFire.WeeklySmsDateResetJob(), Cron.Weekly);

      // BackgroundJob.Schedule(() => _hangFire.PushSms(), TimeSpan.FromSeconds(10));

      // InitializeDatabase(app);

      //if (env.IsDevelopment())
      //    PayAjoSeeder.Seed(_context);

      app.Use(async (context, next) =>
{
  if ((context.Response.StatusCode == 404 || !Path.HasExtension(context.Request.Path.Value))
                                   && !context.Request.Path.Value.StartsWith("/api/"))
  {
    context.Request.Path = "/index.html";
  }

  await next.Invoke();
});




      app.UseStaticFiles();
      app.UseDefaultFiles();

      app.UseMvc();
    }

    private void InitializeDatabase(IApplicationBuilder app)
    {
      using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        scope.ServiceProvider.GetRequiredService<PayAjoContext>().Database.Migrate();
      }
    }
  }
}
