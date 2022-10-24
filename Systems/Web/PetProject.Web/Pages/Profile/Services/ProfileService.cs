using Blazored.LocalStorage;
using PetProject.Web.Pages.Profile.Models;
using System.Text;
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

        public async Task<ErrorResponse> ChangeName(NameModel model)
        {
            var token = await localStorage.GetItemAsync<string>("authToken");

            string url = $"{Settings.ApiRoot}/v1/accounts/change/name/{token}/{model.Name}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var result = new ErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<ErrorResponse>(content);
                return result;
            }

            return result;
        }

        public async Task<ErrorResponse> ChangeSurname(SurnameModel model)
        {
            var token = await localStorage.GetItemAsync<string>("authToken");

            string url = $"{Settings.ApiRoot}/v1/accounts/change/surname/{token}/{model.Surname}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var result = new ErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<ErrorResponse>(content);
                return result;
            }

            return result;
        }

        public async Task<ErrorResponse> ChangePatronymic(PatronymicModel model)
        {
            var token = await localStorage.GetItemAsync<string>("authToken");

            string url = $"{Settings.ApiRoot}/v1/accounts/change/patronymic/{token}/{model.Patronymic}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var result = new ErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<ErrorResponse>(content);
                return result;
            }

            return result;
        }

        public async Task<ErrorResponse> ChangeNickname(NicknameModel model)
        {
            var token = await localStorage.GetItemAsync<string>("authToken");

            string url = $"{Settings.ApiRoot}/v1/accounts/change/nickname/{token}/{model.Nickname}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var result = new ErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<ErrorResponse>(content);
                return result;
            }

            return result;
        }

        public async Task<ErrorResponse> ChangeEmail(EmailModel model)
        {
            var token = await localStorage.GetItemAsync<string>("authToken");

            string url = $"{Settings.ApiRoot}/v1/accounts/change/email/{token}/{model.Email}";

            var response = await _httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            var result = new ErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<ErrorResponse>(content);
                return result;
            }
            return result;

        }

        public async Task<ErrorResponse> ChangePassword(PasswordModel model)
        {
            var token = await localStorage.GetItemAsync<string>("authToken");

            string url = $"{Settings.ApiRoot}/v1/accounts/change/password/{token}";

            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            var result = new ErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<ErrorResponse>(content);
                return result;
            }
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
