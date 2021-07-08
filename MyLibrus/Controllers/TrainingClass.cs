using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyLibrus.Controllers
{
    public class TrainingClass
    {
        public async static Task Tren()
        {

            //IDisposilbe - warto uzyc USING
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient
                    .GetAsync("https://jsonplaceholder.typicode.com/posts");

                var json = await result.Content.ReadAsStringAsync();
            }


        }
    }
}
