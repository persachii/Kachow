using System;
using System.Net.Http.Json;
using Kachow.Shared.DTOs;
using Kachow.Shared.Models;
using Newtonsoft.Json;

namespace Kachow.Client.Services.ParcelNameService
{
	public class ParcelNameService: IParcelNameService
	{
		private HttpClient _client;
		public ParcelNameService(HttpClient client)
		{
			_client = client;
		}

        public async Task<bool> Add(ParcelNameDTO item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync("/api/ParcelName", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public Task<ParcelName> Edit(ParcelName item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ParcelName>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<ParcelName>>("/api/ParcelName");
        }

        public Task<ParcelName> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

