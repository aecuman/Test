using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using System.Text;
using System.Threading.Tasks;

namespace TestClass
{
    [ServiceContract]
    public interface IFood
    {
        
        void PostFood(Food food);
        string GetFood(string Id);
        Food SearchFood(int Id,Food food);
    }
}
