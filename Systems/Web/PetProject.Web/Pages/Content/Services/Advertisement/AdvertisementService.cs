using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Forms;
using PetProject.Web.Pages.Advertisement.Models.Advertisement;
using PetProject.Web.Pages.Advertisement.Models.Breed;
using PetProject.Web.Pages.Advertisement.Models.Color;
using PetProject.Web.Pages.Advertisement.Models.Type;
using PetProject.Web.Pages.Content.Models.Advertisement;
using PetProject.Web.Pages.Content.Models.City;
using PetProject.Web.Pages.Content.Models.Favourite;
using PetProject.Web.Pages.Content.Models.File;
using PetProject.Web.Pages.Content.Models.Subscribe;
using PetProject.Web.Pages.Profile.Models;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Reflection;
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


        public async Task<IEnumerable<AdvertisementResponse>> GetAdvertisements()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == "sub").Value;
            var userId = Guid.Parse(idUser);


            string url = $"{Settings.ApiRoot}/v1/advertisement/all/{userId}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<AdvertisementResponse>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AdvertisementResponse>();

            return data;
        }

        public async Task<IEnumerable<AdvertisementResponse>> GetUserAdvertisements(int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/v1/advertisement?offset={offset}&limit={limit}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<AdvertisementResponse>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AdvertisementResponse>();

            var token = await _localStorage.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == "sub").Value;

            var userId = Guid.Parse(idUser);

            IEnumerable<AdvertisementResponse> userAdvertisementList = data.Where(data => data.UserId == userId);

            return userAdvertisementList;
        }

        public async Task<AdvertisementResponse> GetAdvertisement(int advertisementId)
        {
            string url = $"{Settings.ApiRoot}/v1/advertisement/{advertisementId}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<AdvertisementResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new AdvertisementResponse();

            return data;
        }

        public async Task<ErrorResponse> AddAdvertisement(AdvertisementDialogModel model)
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

        public async Task<ErrorResponse> EditAdvertisement(int advertisementId, AdvertisementDialogModel model)
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

        public async Task<IEnumerable<BreedModel>> GetBreedsWithTypeId(int typeId, int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/v1/breed/with/TypeId/{typeId}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<BreedModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<BreedModel>();

            return data;
        }

        public async Task<AdvertisementFilterModel> GetFilter()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == "sub").Value;
            var userGuid = Guid.Parse(idUser);

            string url = $"{Settings.ApiRoot}/v1/advertisement/getfilter/{userGuid}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            AdvertisementFilterModel? data = new AdvertisementFilterModel();
            if (content != "")
                data = JsonSerializer.Deserialize<AdvertisementFilterModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new AdvertisementFilterModel();

            return data;

        }

        public async Task<IEnumerable<AdvertisementResponse>> AddFilter(AdvertisementFilterModel filtermodel)
        {

            var token = await _localStorage.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == "sub").Value;
            filtermodel.UserId = Guid.Parse(idUser);

            string url = $"{Settings.ApiRoot}/v1/advertisement/addfilter";

            var body = JsonSerializer.Serialize(filtermodel);
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<IEnumerable<AdvertisementResponse>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AdvertisementResponse>();

            return data;
        }

        public async Task<ErrorResponse> DropFilter()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == "sub").Value;
            var userId = Guid.Parse(idUser);

            string url = $"{Settings.ApiRoot}/v1/advertisement/dropfilter/{userId}";

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

        public async Task<FileResponse> GetFile()
        {
            string url = $"{Settings.ApiRoot}/v1/advertisement/getFile";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<FileResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new FileResponse();
            return data;
        }

    }
}