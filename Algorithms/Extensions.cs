using Newtonsoft.Json;
using System.Net.Http;


namespace Algorithms
{
    public static class Extensions
    {
        // using System.Text.Json;
        public static T Parse<T>(this HttpResponseMessage response)
        {
            string content = response.Content?.ReadAsStringAsync().Result;
            return System.Text.Json.JsonSerializer.Deserialize<T>(content);
        }

        // using Newtonsoft.Json;
        public static T Parse2<T>(this HttpResponseMessage response)
        {
            string content = response.Content?.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
