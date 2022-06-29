using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TicketService.Model;

namespace TicketService
{
    public static class Producer
    {
        public static IModel mod;

        public static void producer(  )
        {
            newtest tst = new newtest();
            var factory = new ConnectionFactory
            {
                Uri = new System.Uri("amqp://guest:guest@localhost:5672")
            };
            var conn = factory.CreateConnection();
            var channel = conn.CreateModel();
            mod = channel;
            //Producer.producer(channel, tst);
            mod.QueueDeclare("Senddata", durable: true, exclusive: false, autoDelete: false, arguments: null);

           var body= Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tst));
            mod.BasicPublish("", "Senddata", null, body);
        }
    }
}
