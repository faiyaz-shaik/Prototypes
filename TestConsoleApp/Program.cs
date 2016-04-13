using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace TestConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            

        }

        public async Task Invoke()
        {

            await GetDataAsync();
        }

        async Task GetDataAsync()
        {
            HttpClient client = new HttpClient();
            string con = client.GetStringAsync("http://www.bbc.co.uk");
            
        }
    }
}
