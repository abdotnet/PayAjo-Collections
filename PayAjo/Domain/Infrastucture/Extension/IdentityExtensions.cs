using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.Extension
{
    public static class IdentityExtensions
    {
        //public static void AddApplicationIdentity(this IServiceCollection services, IConfigurationRoot config)
        //{
        //  services.AddIdentity<UserModel, string>(o =>
        //  {
        //    // configure identity options
        //    o.Password.RequireDigit = false;
        //    o.Password.RequireLowercase = false;
        //    o.Password.RequireUppercase = false;
        //    o.Password.RequireNonAlphanumeric = false;
        //    o.Password.RequiredLength = 6;
        //  }).AddDefaultTokenProviders();

        //  services.AddScoped<IUserStore<UserModel>, UserService>();
        //  services.AddScoped<IRoleStore<string>, RoleStore>();

        //  var certText = config.GetValue<string>("Certificate:Text");
        //  var certPassword = config.GetValue<string>("Certificate:Password");

        //  byte[] certBytes = Convert.FromBase64String(certText);

        //  var signingCert = new X509Certificate2(certBytes, certPassword,
        //                          X509KeyStorageFlags.MachineKeySet
        //                          | X509KeyStorageFlags.PersistKeySet
        //                          | X509KeyStorageFlags.Exportable);

        //  var connString = config.GetConnectionString("DataEntities");
        //  var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

        //  var identityServer = services.AddIdentityServer()
        //                               .AddInMemoryClients(IdentityConfig.GetClients())
        //                               .AddInMemoryIdentityResources(IdentityConfig.GetIdentityResources())
        //                               .AddInMemoryApiResources(IdentityConfig.GetApiResources())
        //                               .AddSigningCredential(signingCert)
        //                               .AddOperationalStore(builder => builder.UseSqlServer(connString, options => options.MigrationsAssembly(migrationAssembly)))
        //                               .AddAspNetIdentity<UserModel>();
        //}


        public static async Task<IdentityResult> ToIdentityResult(this Task<Operation> task)
        {
            var operation = await task;
            if (operation.Succeeded)
            {
                return IdentityResult.Success;
            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Code = "IdentityError", Description = operation.Message });
            }
        }

        public static async Task<IdentityResult> ToIdentityResult<T>(this Task<Operation<T>> task)
        {
            var operation = await task;
            if (operation.Succeeded)
            {
                return IdentityResult.Success;
            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Code = "IdentityError", Description = operation.Message });
            }
        }
    }
}
