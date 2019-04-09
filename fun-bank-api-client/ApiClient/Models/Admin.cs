using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace fun_bank_api_client.ApiClient.Models {
    public class Admin : Model {
        [JsonProperty("username", Required = Required.Always)]
        public string Username;

        [JsonProperty("password", Required = Required.Always)]
        public string PasswordHash;

        [JsonProperty("hash", Required = Required.Default)]
        public string Hash;
    }
}
