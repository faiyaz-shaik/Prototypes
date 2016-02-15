using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using FazMart;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NDPServiceBus
{
    class Program
    {
        static void Main(string[] args)
        {

            SendOrders();



        }


        public static void SendOrders()
        {
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");


            QueueClient queue = QueueClient.CreateFromConnectionString(connectionString, "contentitems");

            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1003, Name = "Tablet" });
            products.Add(new Product { Id = 1004, Name = "Fitband" });



            Order order = new Order
            {
                Id = 7869,
                Customer = new Customer { Id = 4523, Name = "NEW LOOK" },
                Products = products
            };


            var json = JsonConvert.SerializeObject(order);

            BrokeredMessage ci = new BrokeredMessage(json);
            ci.Properties["Id"] = order.Id;

            queue.Send(ci);
        }


        public static void testsend()
        {

            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");


            QueueClient queue = QueueClient.CreateFromConnectionString(connectionString, "contentitems");

            for (int i = 1; i < 11; i++)
            {
                // Create message, passing a string message for the body.
                BrokeredMessage message = new BrokeredMessage("Test message " + i);

                // Set some addtional custom app-specific properties.
                message.Properties["TestProperty"] = "TestValue " + i;
                message.Properties["id"] = i;

                // Send message to the queue.
                queue.Send(message);
            }

        }
    }


}
