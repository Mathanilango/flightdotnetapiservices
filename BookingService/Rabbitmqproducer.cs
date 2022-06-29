using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookingservice
{
    public class Rabbitmqproducer
    {
        public void rabirprd(string tr)
        {
            var factory = new ConnectionFactory() { Uri = new System.Uri("amqp://guest:guest@localhost:5672") };
        var connection = factory.CreateConnection();
           var channel = connection.CreateModel();
          
                channel.QueueDeclare(queue: "Data",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = tr;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "Data",
                                     basicProperties: null,
                                     body: body);
                // Console.WriteLine(" [x] Sent {0}", message);
           
        }
    }
}
