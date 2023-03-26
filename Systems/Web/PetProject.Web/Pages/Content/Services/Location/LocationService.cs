using Blazored.LocalStorage;
using PetProject.Web.Pages.Content.Models.City;
using System.Net.Http;
using System.Text.Json;

namespace PetProject.Web.Pages.Content.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;


        public LocationService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<IEnumerable<CityModel>> GetCitiesAsync()
        {
            string url = $"{Settings.ApiRoot}/v1/location";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<CityModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CityModel>();

            return data;
        }
    }
}
