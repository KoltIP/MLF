using PetProject.Web.Pages.Advertisement.Models.Color;
using PetProject.Web.Pages.Content.Models.Color;
using PetProject.Web.Shared.Models;
using System.Text;
using System.Text.Json;

namespace PetProject.Web.Pages.Advertisement.Services.Color
{
    public class ColorService
    {
        private readonly HttpClient _httpClient;

        public ColorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ColorListItems>> GetColors(int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/v1/color?offset={offset}&limit={limit}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<ColorListItems>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ColorListItems>();

            return data;
        }

        public async Task<ColorListItems> GetColor(int ColorId)
        {
            string url = $"{Settings.ApiRoot}/v1/color/{ColorId}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<ColorListItems>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new ColorListItems();

            return data;
        }

        public async Task<ErrorResponse> AddColor(ColorModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/color";

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

        public async Task<ErrorResponse> EditColor(int ColorId, ColorModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/color/{ColorId}";

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

        public async Task<ErrorResponse> DeleteColor(int ColorId)
        {
            string url = $"{Settings.ApiRoot}/v1/color/{ColorId}";

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
