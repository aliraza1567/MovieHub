using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MovieHub.Provider
{
    public class ApiHelper
    {
        public string Request(string apiUrl, Dictionary<string, string> headers, string functionUrl, string authorization, string dataString)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var item in headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                client.DefaultRequestHeaders.Add("Authorization", "Basic " + authorization);


                var response = client.PostAsync(functionUrl, new StringContent(dataString));
                return response.Result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
