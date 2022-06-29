using Adminservice.DBContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adminservice
{
    public class TicketConsumer: BackgroundService
    {
        private IServiceProvider _sp;
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        //private AppDBContext _db;

        // initialize the connection, channel and queue 
        // inside the constructor to persist them 
        // for until the service (or the application) runs

       
        public TicketConsumer(IServiceProvider sp)
        {
            _sp = sp;

            _factory = new ConnectionFactory() { Uri = new System.Uri("amqp://guest:guest@localhost:5672") };

            _connection = _factory.CreateConnection();

            _channel = _connection.CreateModel();


            _channel.QueueDeclare(queue: "Data",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // when the service is stopping
            // dispose these references
            // to prevent leaks
            if (stoppingToken.IsCancellationRequested)
            {
                _channel.Dispose();
                _connection.Dispose();
                return Task.CompletedTask;
            }

            // create a consumer that listens on the channel (queue)
            var consumer = new EventingBasicConsumer(_channel);

            // handle the Received event on the consumer
            // this is triggered whenever a new message
            // is added to the queue by the producer
            consumer.Received += (model, ea) =>
            {
                // read the message bytes
                var body = ea.Body.ToArray();

                // convert back to the original string
                // {index}|SuperHero{10000+index}|Fly,Eat,Sleep,Manga|1|{DateTime.UtcNow.ToLongDateString()}|0|0
                // is received here
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine(" [x] Received {0}", message);


                Task.Run(() =>
                {
                    // split the incoming message
                    // into chunks which are inserted
                    // into respective columns of the Heroes table
                    char[] spearator = { ',' };

                    // using the method
                    string[] strlist = message.Split(spearator);

                    int flightid = Convert.ToInt32(strlist[0]);
                    int seatbooked = Convert.ToInt32(strlist[1]);
                    string seattype = strlist[2];
                    string strg = strlist[3];

                    if (strg == "add" && seattype == "Bussiness")
                    {

                        using (var scope = _sp.CreateScope())
                        {
                            //await Task.Delay(30000);
                            var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                            var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();
                            res.AvailableBusinessSeat = res.AvailableBusinessSeat - seatbooked;
                            dbContext.Flight.Update(res);
                            dbContext.SaveChanges();
                        }

                    }
                    if (strg == "add" && seattype == "Non-Bussiness")
                    {
                        using (var scope = _sp.CreateScope())
                        {
                            //await Task.Delay(30000);
                            var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                            var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();
                            res.AvailableNonBusinessSeat = res.AvailableNonBusinessSeat - seatbooked;
                            dbContext.Flight.Update(res);
                            dbContext.SaveChanges();
                        }
                    }

                   

                    // BackgroundService is a Singleton service
                    // IHeroesRepository is declared a Scoped service
                    // by definition a Scoped service can't be consumed inside a Singleton
                    // to solve this, we create a custom scope inside the Singleton and 
                    // perform the insertion.
                   
                });
            };

    _channel.BasicConsume(queue: "Data",
                         autoAck: true,
                         consumer: consumer);

    return Task.CompletedTask;
        }
    }
}

