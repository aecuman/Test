using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestClientBoost.Models;

namespace TestClientBoost.Controllers
{
    public class foodapiController : ApiController
    {
        public static readonly IFood _food = new FoodRepo();
        // GET api/<controller>
        
        [Route("~/api/foodapi/food/{Name}/_search/")]
        [HttpGet]
        public IEnumerable<Food> SearchFood(string Name)
        {
            
            return _food.SearchFood(Name);
        }

        // GET api/<controller>/5
        public string Get(string Id)
        {
            return _food.GetFood(Id);
        }

        // POST api/<controller>
        public void Post(Food food)
        {
            _food.PostFood(food);
        }

    }
}