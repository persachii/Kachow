using System;
using System.Net.Http.Json;
using Kachow.Shared.DTOs;
using Kachow.Shared.Models;
using Newtonsoft.Json;

namespace Kachow.Client.Services.DeliveryMethodService
{
	public class DeliveryMethodService : IDeliveryMethodService
	{
        private HttpClient _client;
        public DeliveryMethodService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Add(DeliveryMethodDTO item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync("/api/DeliveryMethod", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public Task<DeliveryMethod> Edit(DeliveryMethod item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DeliveryMethod>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<DeliveryMethod>>("/api/DeliveryMethod");
        }

        public Task<DeliveryMethod> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

