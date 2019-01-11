using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StaffManagementMicroservice.DB;

namespace StaffManagementMicroservice
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //Testing changes

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<StaffPermContext>();
                DBInitializer.Initialize(context);
            }

            BuildWebHost(args).Run();


            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
    }
}
