using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatus.WebJob.Core.Helpers
{
    public class HttpClientHelper
    {
        public static T GetContentFromRequest<T>(string url)
        {
            using (var client = new HttpClient())
            {

                var response = client.GetAsync(url).GetAwaiter().GetResult();

                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}
