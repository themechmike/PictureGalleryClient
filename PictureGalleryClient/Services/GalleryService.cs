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
            GalleryApiClient apiClient = new GalleryApiClient(url, httpClient);

            await apiClient.PictureAsync(ownerId, content.Title, content.Description, content.Tags, content.File);
        }

        public async Task<UserItemViewModel[]> CheckUser()
        {
            GalleryApiClient apiClient = new GalleryApiClient(url, httpClient);

            var userList = await apiClient.UserAllAsync();

            return userList.Select(dto => UserItemViewModel.FromDto(dto)).ToArray();
        }

        public async Task<Guid> AddUserAsync(UserDTO user)
        {
            GalleryApiClient apiClient = new GalleryApiClient(url, httpClient);
            
            var returnedValue = await apiClient.UserAsync(user);
            
            return returnedValue;
        }

        public async Task<GalleryItemViewModel[]> GetGalleryItemsAsync(string ownerId)
        {
            GalleryApiClient apiClient = new GalleryApiClient(url, httpClient);
            
            var dtoGalleryItems = await apiClient.PictureAllAsync(ownerId);
            
            return dtoGalleryItems.Select(dto => GalleryItemViewModel.FromDto(dto)).ToArray();
        }

        public async Task<string> DeletePictureAsync(Guid pictureId, string ownerId)
        {
            GalleryApiClient apiClient = new GalleryApiClient(url, httpClient);
            await apiClient.Picture2Async(pictureId.ToString(), ownerId);

            return null; 
        }

    }
}
