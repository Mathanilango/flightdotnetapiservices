﻿using Loginservice;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
                CreateWebHostBuilder(args).Build().Run();
           
           
           
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
        .UseUrls("http://localhost:8001");
        
    }
}
