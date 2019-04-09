using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using fun_bank_api_client.ApiClient.Models;

namespace fun_bank_api_client {
    public class AdminApiClient : FunBankApiClient {
        public Admin self;

        public AdminApiClient(string baseUrl) : base(baseUrl) {

        }

        public async Task Login(string username, string password) {
            self = await Post<Admin>("/api/login/admin", new Dictionary<string, object>() {
                {"username", username},
                {"password", password}
            });
        }

        public async Task<Admin> Create(string username, string password) {
            return await Post<Admin>("/api/admin", new Dictionary<string, object>() {
                {"username", username},
                {"password", password}
            });
        }
        public async Task<Account> CreateAccount(Customer owner, string password) {
            return await Post<Account>("/api/admin", new Dictionary<string, string>() {
                {"customer", owner.Id},
                {"password", password}
            });
        }

        public async Task<Admin> GetById(string id) {
            return await Get<Admin>($"/api/admin/{id}", null);
        }

    }
}
