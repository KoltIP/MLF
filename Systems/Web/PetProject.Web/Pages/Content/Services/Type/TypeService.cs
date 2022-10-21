using PetProject.Web.Pages.Advertisement.Models.Type;
using PetProject.Web.Pages.Content.Models.Type;
using PetProject.Web.Pages.Profile.Models;
using System.Text;
using System.Text.Json;

namespace PetProject.Web.Pages.Advertisement.Services.Type
{
    public class TypeService : ITypeService
    {
        private readonly HttpClient _httpClient;

        public TypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TypeListItems>> GetTypies(int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/v1/type?offset={offset}&limit={limit}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<TypeListItems>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<TypeListItems>();

            return data;
        }

        public async Task<TypeListItems> GetType(int TypeId)
        {
            string url = $"{Settings.ApiRoot}/v1/type/{TypeId}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<TypeListItems>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new TypeListItems();

            return data;
        }

        public async Task<ErrorResponse> AddType(TypeModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/type";

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

        public async Task<ErrorResponse> EditType(int TypeId, TypeModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/type/{TypeId}";

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

        public async Task<ErrorResponse> DeleteType(int TypeId)
        {
            string url = $"{Settings.ApiRoot}/v1/type/{TypeId}";

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
