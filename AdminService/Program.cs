using Adminservice.DBContext;
using Adminservice.Interface;
using Adminservice.Repository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminservice
{
    
    public class Program
    {


        private static readonly AppDBContext _context;
        //public SqlAdminRepository(AppDBContext Context)
        //{
        //    _context = Context;
        //}
        public static  void Main(string[] args)
        {
          //  AppDBContext cont;
            //_context = cont;
            //var ts = _context;
                CreateWebHostBuilder(args).Build().Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
