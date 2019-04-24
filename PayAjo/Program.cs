using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;


namespace PayAjo
{
  /// <summary>
  /// Start up program ...
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Application Initializer
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static int Main(string[] args)
    {
      try
      {
        var currentEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{currentEnv}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        Log.Logger = new LoggerConfiguration()

            .ReadFrom.Configuration(configuration).WriteTo.Console()
            //.WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "log-{Date}.txt"))
            .CreateLogger();

        Log.Information("Starting web host");
        CreateWebHostBuilder(args).Build().Run();
        return 0;
      }
      catch (Exception ex)
      {
        Log.Fatal(ex, "Host terminated unexpectedly");
        return 1;
      }
      finally
      {
        Log.CloseAndFlush();
      }
    }
    /// <summary>
    /// Create Web host builder
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
      return WebHost.CreateDefaultBuilder(args)
                     .UseStartup<Startup>()
                     .UseSerilog();
    }


  }
}
