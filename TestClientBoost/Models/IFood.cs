using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestClientBoost.Models
{
   
    public interface IFood
    {
        void PostFood(Food food);
        string GetFood(string Id);
        IEnumerable<Food> SearchFood(string Name);


    }
}