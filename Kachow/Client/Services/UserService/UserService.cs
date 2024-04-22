using System;
using System.Net.Http.Json;
using Kachow.Shared.DTOs;
using Kachow.Shared.Models;
using Newtonsoft.Json;

namespace Kachow.Client.Services.UserService
{
	public class UserService : IUserService
	{
        private HttpClient _client;
        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Add(UserRegisterRequest item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync("/api/User/register", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public Task<User> Edit(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<User>>("/api/User");
        }

        public Task<User> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

