using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace fun_bank_api_client {
    public class FunBankApiClient {
        private Uri baseUrl = new Uri("http://localhost/");
        private CookieContainer cookieContainer;
        private HttpClientHandler httpClientHandler;
        private HttpClient httpClient;

        public FunBankApiClient(string baseUrl) {
            this.baseUrl = new Uri(baseUrl);
            cookieContainer = new CookieContainer();
            httpClientHandler = new HttpClientHandler() {
                CookieContainer = cookieContainer
            };
            httpClient = new HttpClient() {
                BaseAddress = this.baseUrl
            };
        }

        public string GetQueryString(Dictionary<string, string> query) {
            if(query == null || query.Count == 0) {
                return "";
            } else {
                string result = "";
                int count = 0;
                foreach (KeyValuePair<string, string> pair in query) {
                    if (count++ == 0) {
                        result += $"?{HttpUtility.UrlEncode(pair.Key)}={HttpUtility.UrlEncode(pair.Value)}";
                    } else {
                        result += $"&{HttpUtility.UrlDecode(pair.Key)}={HttpUtility.UrlEncode(pair.Value)}";
                    }
                }
                return result;
            }
        }

        public async Task<T> ParseResponse<T>(HttpResponseMessage response) {
            response.EnsureSuccessStatusCode();
            IEnumerable<string> values;
            if(response.Headers.TryGetValues("Content-Type", out values)) {
                if(new List<string>(values).Contains("application/json")) {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                } else {
                    return default;
                }
            } else {
                return default;
            }
        }

        public async Task<T> Get<T>(string path, Dictionary<string, string> query) {
            var address = new UriBuilder(httpClient.BaseAddress) {
                Path = path,
                Query = GetQueryString(query)
            }.ToString();
            var response = await httpClient.GetAsync(address);
            return await ParseResponse<T>(response);
        }

        public async Task<T> Post<T>(string path, object body) {
            var address = new UriBuilder(httpClient.BaseAddress) {
                Path = path
            }.ToString();
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(address, content);
            return await ParseResponse<T>(response);
        }
    }
}
