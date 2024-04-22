
using System.Net.Http.Json;
using Kachow.Shared.DTOs;
using Kachow.Shared.Models;
using Newtonsoft.Json;

namespace Kachow.Client.Services.ParcelService
{
    public class ParcelService : IParcelService
    {
        private HttpClient _client;
        public ParcelService(HttpClient client)
        {
            _client = client;
        }
        public string Message { get; set; } = "Loading products...";

        public async Task<bool> Add(ParcelDTO item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync("/api/Parcel", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);

        }

        public Task<Parcel> Edit(Parcel item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Parcel>> GetAll()
        {
            
            try
            {
                var response = await _client.GetAsync("/api/Parcel"); ;

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Parcel>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<Parcel>>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            } 

            //return await _client.GetFromJsonAsync<List<Parcel>>("/api/Parcel");

        }

        public async Task<List<TrackedParcelDTO>> GetAllTrackedParcels()
        {
            return await _client.GetFromJsonAsync<List<TrackedParcelDTO>>("/api/Parcel/trackedparcel");
        }

        public async Task<TrackedParcelDTO> GetAllTrackedParcel(int id)
        {
            try
            {
                var response = await _client.GetAsync($"/api/Parcel/trackedparcel/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(TrackedParcelDTO);
                    }

                    return await response.Content.ReadFromJsonAsync<TrackedParcelDTO>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            //return await _client.GetFromJsonAsync<TrackedParcelDTO>($"/api/Parcel/trackedparcel/{id}");
        }

        public async Task<Parcel> GetOne(int id)
        {

            return await _client.GetFromJsonAsync<Parcel>($"/api/Parcel/{id}");

        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/parcel/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);

        }
    }

}


