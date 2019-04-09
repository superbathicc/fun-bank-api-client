using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace fun_bank_api_client.ApiClient.Models {
    public class Account : Model {
        [JsonProperty("accountId", Required = Required.Always)]
        public string AccountNumber;

        [JsonProperty("password", Required = Required.Always)]
        public string PasswordHash;

        [JsonProperty("balance", Required = Required.Always)]
        public float Balance;

        [JsonProperty("hash", Required = Required.Default)]
        public string Hash;

        [JsonProperty("customer", Required = Required.Always)]
        public string CustomerId;

    }
}
