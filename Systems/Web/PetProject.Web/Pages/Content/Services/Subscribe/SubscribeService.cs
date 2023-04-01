using PetProject.Web.Pages.Advertisement.Models.Advertisement;
using PetProject.Web.Pages.Content.Models.Subscribe;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Blazored.LocalStorage;
using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Content.Services.Subscribe
{
    public class SubscribeService : ISubscribeService
    {

        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;


        public SubscribeService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }


        public async Task<IEnumerable<AdvertisementResponse>> GetAllSubscribe()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == "sub").Value;

            string url = $"{Settings.ApiRoot}/v1/subscribe/{idUser}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<AdvertisementResponse>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AdvertisementResponse>();

            return data;
        }


        public async Task AddSubscribe(int advertisementId)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == "sub").Value;

            SubscribeModel model = new SubscribeModel()
            {
                AdvertisementId = advertisementId,
                UserId = Guid.Parse(idUser)
            };

            string url = $"{Settings.ApiRoot}/v1/subscribe/add";

            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

        }


        public async Task<ErrorResponse> DropSubscribe(int id)
        {
            string url = $"{Settings.ApiRoot}/v1/subscribe/{id}";

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
