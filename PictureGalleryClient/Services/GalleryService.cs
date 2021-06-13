using Newtonsoft.Json;
using PictureGalleryClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PictureGalleryClient.Services
{
    public class GalleryService : IGalleryService
    {
        string url = "http://localhost:21285";

        HttpClient httpClient = new HttpClient();

        public async Task AddPictureAsync(GalleryItemViewModel content, string ownerId)
        {
            var formContent = new MultipartFormDataContent();

            var FilePath = @"f:\Downloads\orig_art-fo4-power-armor-3d46d.jpg";

            formContent.Add(new StreamContent(File.OpenRead(FilePath)), "files", Path.GetFileName(FilePath));
            httpClient.BaseAddress = new Uri(url);
            var response = await httpClient.PostAsync("api/Picture/" + ownerId, formContent);
        }

        public async Task<UserItemViewModel[]> CheckUser()
        {
            GalleryWebApiClient apiClient = new GalleryWebApiClient(url, httpClient);

            var userList = await apiClient.UserAllAsync();

            return userList.Select(dto => UserItemViewModel.FromDto(dto)).ToArray();
        }

        /*
        public async Task<Guid> AddPictureAsync (GalleryItemViewModel galleryItem, string ownerId)
        {
            GalleryWebApiClient apiClient = new GalleryWebApiClient(url, httpClient);
            
            Guid returnedValue = await apiClient.PictureAsync(ownerId, galleryItem.ToDto());
            
            return returnedValue;           
        }
        */

        public async Task<Guid> AddUserAsync(UserDTO user)
        {
            GalleryWebApiClient apiClient = new GalleryWebApiClient(url, httpClient);
            
            var returnedValue = await apiClient.UserAsync(user);
            
            return returnedValue;
        }

        public async Task<GalleryItemViewModel[]> GetGalleryItemsAsync(string ownerId)
        {
            GalleryWebApiClient apiClient = new GalleryWebApiClient(url, httpClient);
            
            var dtoGalleryItems = await apiClient.PictureAllAsync(ownerId);
            
            return dtoGalleryItems.Select(dto => GalleryItemViewModel.FromDto(dto)).ToArray();
        }
    }
}
