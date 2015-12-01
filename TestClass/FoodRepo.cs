using Elasticsearch.Net;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestClass
{
       
    public class FoodRepo:IFood
    {

        private static ConnectionMultiplexer redisConn = ConnectionMultiplexer.Connect("localhost");
        IDatabase redDB = redisConn.GetDatabase();
        ElasticsearchClient ESclient = new ElasticsearchClient();
        public void PostFood(Food food)
        {
            var response = ESclient.Index<Food>("food",food.Type,food.Name,food.Id);
            redDB.StringSet(food.Id, food.Name);

        }
        public string GetFood(string Id)
        {
            IDatabase redDB = redisConn.GetDatabase();

            return redDB.StringGet(Id);
        }
        public Food SearchFood(int Id,Food food)
        {
           
            var ES_Search = ESclient.Search<Food>(Id, x => x
           .SuggestSize(100)
          .AddQueryString("food", food.Name)
           // .AllowNoIndices(false)            
           );
            return ES_Search.Response;
        }
    }
}
