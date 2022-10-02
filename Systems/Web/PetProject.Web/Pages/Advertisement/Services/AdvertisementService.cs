
using PetProject.Web.Pages.Advertisement.Models;
using PetProject.Web.Shared.Models;
using System.Text;
using System.Text.Json;

namespace PetProject.Web.Pages.Advertisement.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly HttpClient _httpClient;

        public AdvertisementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AdvertisementListItems>> GetAdvertisements(int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/v1/advertisement?offset={offset}&limit={limit}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<AdvertisementListItems>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AdvertisementListItems>();

            return data;
        }

        public async Task<AdvertisementListItems> GetAdvertisement(int advertisementId)
        {
            string url = $"{Settings.ApiRoot}/v1/advertisement/{advertisementId}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<AdvertisementListItems>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new AdvertisementListItems();

            return data;
        }

        public async Task<ErrorResponse> AddAdvertisement(AdvertisementModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/advertisement";

            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            var error = new ErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                error = JsonSerializer.Deserialize<ErrorResponse>(content);
                if (error.ErrorCode == -1)
                    error.Message = "An unexpected error has occurred. Transaction rejected.";
            }
            return error;

        }

        public async Task<ErrorResponse> EditAdvertisement(int advertisementId, AdvertisementModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/advertisement/{advertisementId}";

            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            var error = new ErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                error = JsonSerializer.Deserialize<ErrorResponse>(content);
                if (error.ErrorCode == -1)
                    error.Message = "An unexpected error has occurred. Transaction rejected.";
            }
            return error;
        }

        public async Task<ErrorResponse> DeleteAdvertisement(int advertisementId)
        {
            string url = $"{Settings.ApiRoot}/v1/advertisement/{advertisementId}";

            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var error = new ErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                error = JsonSerializer.Deserialize<ErrorResponse>(content);
                if (error.ErrorCode == -1)
                    error.Message = "An unexpected error has occurred. Transaction rejected.";
            }
            return error;
        }
    }
}

