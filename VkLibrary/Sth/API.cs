using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VkLibrary.Exceptions;

namespace VkLibrary.Sth
{
    class API
    {
        const string apiUrl = "https://api.vk.com/";

        internal static async Task<T> CreateAsync<T>(string methodName, Dictionary<string, string> @params)
        {
            Client.Instance.DefaultRequestHeaders.Accept.Clear();
            Client.Instance.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await Client.Instance.PostAsync(
                    $"{apiUrl}method/{methodName}", new FormUrlEncodedContent(@params));

                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                JObject jObj = JObject.Parse(json);

                if (jObj["error"] != null)
                {
                    var error = jObj["error"];
                    throw new VkLibraryException($"{error["error_msg"]}");
                }

                T t = jObj["response"].ToObject<T>();
                return t;
            }
            catch (Exception ex)
            {
                throw new VkLibraryException(ex.Message);
            }
        }
    }
}
