using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient("http://localhost:31817/");
            //string str = client.Get("api/values");

            client = new RestClient("http://123.59.51.46:8080");
            string str = client.Post(@"{""userId"":""1111"",""status"":""1""}","/app_api/getRaceList");

            Console.WriteLine(str);

            Console.ReadKey();
        }
    }
}
