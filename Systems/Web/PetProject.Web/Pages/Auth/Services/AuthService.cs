﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PetProject.Web.Pages.Auth.Models.ForgotPassword;
using PetProject.Web.Pages.Auth.Models.Login;
using PetProject.Web.Pages.Auth.Models.Registration;
using PetProject.Web.Providers;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PetProject.Web.Pages.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResponse> Login(LoginModel loginModel)
        {
            var url = $"{Settings.IdentityRoot}/connect/token";

            var request_body = new[]
            {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("client_id", Settings.ClientId),
            new KeyValuePair<string, string>("client_secret", Settings.ClientSecret),
            new KeyValuePair<string, string>("username", loginModel.Email!),
            new KeyValuePair<string, string>("password", loginModel.Password!)
        };

            var requestContent = new FormUrlEncodedContent(request_body);

            var response = await _httpClient.PostAsync(url, requestContent);

            var content = await response.Content.ReadAsStringAsync();

            var loginResult = JsonSerializer.Deserialize<LoginResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new LoginResponse();
            loginResult.Successful = response.IsSuccessStatusCode;

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult.AccessToken);
            await _localStorage.SetItemAsync("refreshToken", loginResult.RefreshToken);

            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email!);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.AccessToken);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("refreshToken");

            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();

            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegistrationErrorResponse> Registration(RegistrationModel registrationModel)
        {

            string url = $"{Settings.ApiRoot}/v1/accounts";

            var body = JsonSerializer.Serialize(registrationModel);
            var request = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();


            var result = new RegistrationErrorResponse();
            result.Successful = response.IsSuccessStatusCode;
            if (!response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<RegistrationErrorResponse>(content);
                return result;
            }
            return result;
        }

        public async Task<bool> InspectEmail(string email)
        {
            string url = $"{Settings.ApiRoot}/v1/accounts/inspect/{email}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var result = JsonSerializer.Deserialize<bool>(content);

            return result;
        }

        public async Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/accounts/forgot/password";

            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            var result = new ForgotPasswordResponse();
            result.Successful = response.IsSuccessStatusCode;
            if (!response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<ForgotPasswordResponse>(content);
                return result;
            }
            return result;

        }

        
    }
}
