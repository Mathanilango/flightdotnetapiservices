using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservice
{
    public class Rabbitmqcnst
    {
        public const string RabbitMqRootUri = "rabbitmq://localhost";
        public const string RabbitMqUri = "rabbitmq://localhost/todoQueue";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string NotificationServiceQueue = "notification.service";
    }
}
