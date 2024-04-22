using System;
using System.Net.Http.Json;
using Kachow.Shared.DTOs;
using Kachow.Shared.Models;
using Newtonsoft.Json;

namespace Kachow.Client.Services.DeliveryStatusService
{
	public class DeliveryStatusService : IDeliveryStatusService
	{
        private HttpClient _client;
        public DeliveryStatusService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Add(DeliveryStatusDTO item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync("/api/DeliveryStatus", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public Task<DeliveryStatus> Edit(DeliveryStatus item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DeliveryStatus>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<DeliveryStatus>>("/api/DeliveryStatus");
        }

        public Task<DeliveryStatus> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

