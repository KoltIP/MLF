using Blazored.LocalStorage;
using PetProject.Web.Pages.Profile.Models;
using System.Text.Json;

namespace PetProject.Web.Pages.Profile.Services
{

    public class ProfileService : IProfileService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService localStorage;

        public ProfileService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            this._httpClient = httpClient;
            this.localStorage = localStorage;
        }

        public async Task<ProfileModel> GetProfile()
        {
            var token = await localStorage.GetItemAsync<string>("authToken");

            string url = $"{Settings.ApiRoot}/v1/accounts/find/{token}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var result = new ProfileModel();
            if (!response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<ProfileModel>(content);
                return result;
            }
            result = JsonSerializer.Deserialize<ProfileModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new ProfileModel();

            return result;
        }

        public async Task DeleteProfile()
        {
            var token = await localStorage.GetItemAsync<string>("authToken");

            string url = $"{Settings.ApiRoot}/v1/accounts/delete/{token}";

            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();            
        }
    }
}
