
using Elasticsearch.Net;
using Elasticsearch.Net.Connection;
using Nest;
using StackExchange.Redis;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestClientBoost.Models
{

    public class FoodRepo:IFood
    {
        private static ConnectionMultiplexer redisConn = ConnectionMultiplexer.Connect("localhost");
        IDatabase redDB = redisConn.GetDatabase();
        public FoodRepo(){
            
           
        }
        public void PostFood(Food food)
        {
            var ESclient = new ElasticsearchClient();
            var response = ESclient.Index<Food>("food", food.Type, food.Id, food);
            redDB.StringSet(food.Id, food.Name);

        }
        public string GetFood(string Id)
        {
            
        IDatabase redDB = redisConn.GetDatabase();
       

            return redDB.StringGet(Id);

        }
       
        public IEnumerable<Food> SearchFood(string Name)
        {
            
            var EsClient = new ElasticClient();

            var ES_Search = EsClient.Search<Food>(s => s
            .Index("food")
            .Type(Name)
            .From(0)
            .Size(10)
            .Query(q => q
                        .QueryString(ps => ps
                        .DefaultField(o => o.Name)



            )));
            return ES_Search.Documents;
                           
        }


       

    }
}