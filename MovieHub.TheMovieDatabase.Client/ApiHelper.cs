using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieHub.Provider
{
    public class ApiHelper
    {
        public async Task<string> Request(string apiUrl, Dictionary<string, string> headers, string functionUrl, string authorization, string dataString)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                if (authorization != null)
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Basic " + authorization);
                }

                var response = await client.GetAsync(functionUrl);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
