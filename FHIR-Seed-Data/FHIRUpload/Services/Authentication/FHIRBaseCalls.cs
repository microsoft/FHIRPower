
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FHIRUpload.Services.Authentication
{
    public class FHIRBaseCalls
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">HttpClient used to call the protected API</param>
        public FHIRBaseCalls(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected HttpClient HttpClient { get; private set; }


        /// <summary>
        /// Calls the protected Web API and processes the result
        /// </summary>
        /// <param name="webApiUrl">Url of the Web API to call (supposed to return Json)</param>
        /// <param name="accessToken">Access token used as a bearer security token to call the Web API</param>
        /// <param name="processResult">Callback used to process the result of the call to the Web API</param>
        public async Task<JObject> GetWebApiAndProcessResultASync(string webApiUrl, string accessToken, Action<JObject> processResult)
        {
            JObject jsonObject = null;
            if (!string.IsNullOrEmpty(accessToken))
            {
                var defaultRequestHeaders = HttpClient.DefaultRequestHeaders;
                if (defaultRequestHeaders.Accept == null || !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
                {
                    HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                defaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);

                HttpResponseMessage response = await HttpClient.GetAsync(webApiUrl);


                string json = await response.Content.ReadAsStringAsync();
                jsonObject = JsonConvert.DeserializeObject(json) as JObject;



            }
            return jsonObject;
        }

        public async Task<JObject> DeleteWebApiAndProcessResultASync(string webApiUrl, string accessToken, Action<JObject> processResult)
        {
            JObject jsonObject = null;
            if (!string.IsNullOrEmpty(accessToken))
            {
                var defaultRequestHeaders = HttpClient.DefaultRequestHeaders;
                if (defaultRequestHeaders.Accept == null || !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
                {
                    HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                defaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);

                HttpResponseMessage response = await HttpClient.DeleteAsync(webApiUrl);


                string json = await response.Content.ReadAsStringAsync();
                jsonObject = JsonConvert.DeserializeObject(json) as JObject;
            }

            return jsonObject;

        }

        public async Task<JObject> PostWebApiAndProcessResultASync(string webApiUrl, string accessToken, Action<JObject> processResult, StringContent data)
        {
            JObject jsonObject = null;
            if (!string.IsNullOrEmpty(accessToken))
            {
                var defaultRequestHeaders = HttpClient.DefaultRequestHeaders;
                if (defaultRequestHeaders.Accept == null || !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
                {
                    HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                defaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);

                HttpResponseMessage response = await HttpClient.PostAsync(webApiUrl, data);


                string json = await response.Content.ReadAsStringAsync();
                jsonObject = JsonConvert.DeserializeObject(json) as JObject;
            }
            return jsonObject;
        }

        public async Task<JObject> PatchWebApiAndProcessResultASync(string webApiUrl, string accessToken, Action<JObject> processResult, StringContent data)
        {
            JObject jsonObject = null;
            if (!string.IsNullOrEmpty(accessToken))
            {
                var defaultRequestHeaders = HttpClient.DefaultRequestHeaders;
                if (defaultRequestHeaders.Accept == null || !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
                {
                    HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                defaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);

                HttpResponseMessage response = await HttpClient.PatchAsync(webApiUrl, data);


                string json = await response.Content.ReadAsStringAsync();
                jsonObject = JsonConvert.DeserializeObject(json) as JObject;
            }
            return jsonObject;
        }
    }
}