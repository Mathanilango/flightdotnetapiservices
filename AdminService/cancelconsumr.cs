using Adminservice.Interface;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminservice
{
    public class cancelconsumr
    {
        private readonly IAdmin _Iadmin;
        private readonly IServiceScopeFactory _scope;
        public cancelconsumr(IAdmin iadmin, IServiceScopeFactory sf)
        {
            _Iadmin = iadmin;
            _scope = sf;
        }
        public void rabbitcns()
        {


            //IAdmin _Iadmin = iadmin;
            string msg = "";
            var factory = new ConnectionFactory() { Uri = new System.Uri("amqp://guest:guest@localhost:5672") };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "CancelTicket",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                msg = message;
                //Console.WriteLine(" [x] Received {0}", message);
                if (msg != "" && msg != null)
                {
                    //Airline air = new Airline();
                    //air.Name = msg;
                    _Iadmin.seatcount(msg, _scope);


                }


            };
            channel.BasicConsume(queue: "CancelTicket",
                                            autoAck: true,
                                            consumer: consumer);








        }
    }
}
