using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminservice
{
    public class rabbitmqproducer
    {
        public void rabirprd(string seat)
        {
            var factory = new ConnectionFactory() { Uri = new System.Uri("amqp://guest:guest@localhost:5672") };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message =seat;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
               // Console.WriteLine(" [x] Sent {0}", message);
            }

       
        }
    }
}
