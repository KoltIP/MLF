﻿using Blazored.LocalStorage;
using System.Text.Json;
using System.Text;
using PetProject.Web.Pages.Content.Models.File;
using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Content.Services.File
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;


        public FileService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }



        public async Task SaveFiles(List<FileModel> files)
        {
            string url = $"{Settings.ApiRoot}/v1/file";

            FileModel file = files.First();
            var body = JsonSerializer.Serialize(file);
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
        }

        public async Task GetFile()
        {
            string url = $"{Settings.ApiRoot}/v1/file";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<byte>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<byte>();
            var bytes = data.ToArray();

        }
    }
}