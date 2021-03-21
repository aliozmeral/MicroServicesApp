using Contact.API.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.API.RabbitMQ
{
    public class ReportSender
    {
        public void Sender()
        {
            var email = new Report
            {
                Konum = "adad",
                KisiSayisi = 2,
                Durum = "Hazırlanıyor"
            };

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "report", durable: false, exclusive: false, autoDelete: false, arguments: null);

                string message = JsonConvert.SerializeObject(email);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "report", basicProperties: null, body: body);

                //Console.WriteLine("Gönderilen report içeriği:", message);
            }

        }
    }
}
