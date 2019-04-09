using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace fun_bank_api_client.ApiClient.Models {
    public class Customer : Model {
        [JsonProperty("Hash")]
        public string Hash;

        [JsonProperty("username", Required = Required.Always)]
        public string Username;

        [JsonProperty("password", Required = Required.Always)]
        public string PasswordHash;

        [JsonProperty("name")]
        public CustomerName Name;

        [JsonProperty("dateOfBirth")]
        public long DateOfBirthMS;

        public DateTime DateOfBirth {
            get {
                return new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToDouble(DateOfBirthMS));
            }
        }

        [JsonProperty("address")]
        public CustomerAddress Address;
    }

    public class CustomerName {
        [JsonProperty("first")]
        public string First;

        [JsonProperty("last")]
        public string Last;
    }

    public class CustomerAddress {
        [JsonProperty("country")]
        public string Country;

        [JsonProperty("city")]
        public string City;

        [JsonProperty("postcode")]
        public string Postcode;

        [JsonProperty("street")]
        public string Street;

        [JsonProperty("houseNumber")]
        public string HouseNumber;
    }
}
