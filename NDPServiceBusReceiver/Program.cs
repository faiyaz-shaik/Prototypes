using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.IO;
using FazMart;
using Newtonsoft.Json;

namespace NDPServiceBusReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            QueueClient queue = QueueClient.CreateFromConnectionString(connectionString, "contentitems");

            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            

            queue.OnMessage((message) =>
            {
                try
                {
                    string messageBody = message.GetBody<string>();
                    Console.WriteLine("Body: " + messageBody);
                    //WriteLineToFile("Body: " + message.GetBody<string>());

                    Order order = JsonConvert.DeserializeObject<Order>(messageBody);

                    Console.WriteLine("Order : " + order.Id + ":" + order.Customer.Name);

                    Console.WriteLine("Message Id: " + message.MessageId);
                    //WriteLineToFile("Message Id: " + message.MessageId);

                    Console.WriteLine("Property.Id " + message.Properties["id"]);
                    //WriteLineToFile("Property.Id " + message.Properties["id"]);

                    message.Complete();
                    //WriteLineToFile("Message Completed");
                }
                catch (Exception exp)
                {
                    message.Abandon();
                    Console.WriteLine(exp.Message + ":Abandon");
                    //WriteLineToFile("Abandon");
                }
            }, options);


            Console.ReadLine();

        }



        public static void WriteLineToFile(string message)
        {


            StreamWriter file = new StreamWriter(@"c:\data\logs\entbuslogs.txt");

            try {
                file.WriteLine("[{0} {1}] {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), message);
            }
            catch
            {

            }
            finally
            {
                file.Close();
            }


                
        }

    }
}
