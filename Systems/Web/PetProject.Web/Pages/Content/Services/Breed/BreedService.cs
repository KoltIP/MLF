using PetProject.Web.Pages.Advertisement.Models.Breed;
using PetProject.Web.Pages.Content.Models.Breed;
using PetProject.Web.Pages.Profile.Models;
using System.Text;
using System.Text.Json;

namespace PetProject.Web.Pages.Breed.Services.Breed
{
    public class BreedService
    {
        private readonly HttpClient _httpClient;

        public BreedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BreedListItems>> GetBreeds(int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/v1/breed?offset={offset}&limit={limit}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<BreedListItems>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<BreedListItems>();

            return data;
        }

        public async Task<BreedListItems> GetBreed(int BreedId)
        {
            string url = $"{Settings.ApiRoot}/v1/breed/{BreedId}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<BreedListItems>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new BreedListItems();

            return data;
        }

        public async Task<ErrorResponse> AddBreed(BreedModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/breed";

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

        public async Task<ErrorResponse> EditBreed(int BreedId, BreedModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/breed/{BreedId}";

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

        public async Task<ErrorResponse> DeleteBreed(int BreedId)
        {
            string url = $"{Settings.ApiRoot}/v1/breed/{BreedId}";

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
