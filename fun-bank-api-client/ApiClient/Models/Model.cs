using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace fun_bank_api_client.ApiClient.Models {
    public class Model {
        [JsonProperty("_id", Required = Required.Always)]
        public string Id;
    }
}
