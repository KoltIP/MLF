using Blazored.LocalStorage;
using PetProject.Web.Pages.Advertisement.Models.Advertisement;
using PetProject.Web.Pages.Advertisement.Models.Breed;
using PetProject.Web.Pages.Advertisement.Models.Color;
using PetProject.Web.Pages.Advertisement.Models.Type;
using PetProject.Web.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace PetProject.Web.Pages.Advertisement.Services.Advertisement
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AdvertisementService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
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

        public async Task<IEnumerable<AdvertisementListItems>> GetUserAdvertisements(int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/v1/advertisement?offset={offset}&limit={limit}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<AdvertisementListItems>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AdvertisementListItems>();

            var token = await _localStorage.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == "sub").Value;

            var userId = Guid.Parse(idUser);

            IEnumerable<AdvertisementListItems> userAdvertisementList = data.Where(data => data.UserId == userId);

            return userAdvertisementList;
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
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == "sub").Value;

            model.UserId = Guid.Parse(idUser);
            model.Id = 1;

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


        public async Task<IEnumerable<BreedModel>> GetBreedList()
        {
            string url = $"{Settings.ApiRoot}/v1/breed";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<BreedModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<BreedModel>();

            return data;
        }

        public async Task<IEnumerable<ColorModel>> GetColorList()
        {
            string url = $"{Settings.ApiRoot}/v1/color";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<ColorModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ColorModel>();

            return data;
        }

        public async Task<IEnumerable<TypeModel>> GetTypeList()
        {
            string url = $"{Settings.ApiRoot}/v1/type";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<TypeModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<TypeModel>();

            return data;
        }


    }
}

