using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {

            var cust = new Customer() { Id = 1002, Name = "Safura Bibi" };

            var prod1 = new Product();
            prod1.Id = 1;
            prod1.Name = "iPhone";

            var prod2 = new Product();
            prod2.Id = 2;
            prod2.Name = "Computer";

            var prod3 = new Product() ;
            prod3.Id = 3;
            prod3.Name = "Blutooth Sync";


            var order = new Order();

            //{ Id = 1, Customer = cust, Products =  { prod1, prod2} };

            order.Id = 2;
            order.Customer = cust;

           List<Product> orderproducts = new List<Product>();

            orderproducts.Add(prod2);
            orderproducts.Add(prod3);


            order.Products = orderproducts;


            string output = JsonConvert.SerializeObject(order);

            Console.ReadLine();


        }
    }
}
