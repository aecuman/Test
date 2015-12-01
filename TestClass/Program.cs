using System;
using System.Net;
using System.Runtime.Serialization.Json;

namespace TestClass
{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            Food foodie = new Food { Id = "1", Name = "Ovacado", Type = "fruit" };

            PostFood(foodie);
            Console.WriteLine("Id:{0} Name:{1} Type:{2}", foodie.Id, foodie.Name, foodie.Type);
            GetFood("1");
            SearchFood("fruit");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
         static void PostFood(Food food)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                var uri = new Uri("http://localhost:3401/api/foodapi/");
                using (var stream = client.OpenWrite(uri, "POST"))
                {
                    var serializer = new DataContractJsonSerializer(typeof(Food));
                    serializer.WriteObject(stream, food);
                    stream.Close();
                }
            }



        }
         static string GetFood(string Id)
        {
            using (var client = new WebClient())
            {
                var uri = new Uri(
                  string.Format("http://localhost:3401/api/foodapi/{0}", Id));
                string value=client.DownloadString(uri);
                Console.WriteLine(value);
                return value;
               
            }
        }
        static string SearchFood(string Name)
        {
            using (var client = new WebClient())
            {
            

                var uri = new Uri(string.Format("http://localhost:3401/api/foodapi/food/{0}/_search/",Name));
                Console.WriteLine(uri);
             
                string value=client.DownloadString(uri);

                Console.WriteLine(value);
                return value;          
               
            }

        }

    }
}
