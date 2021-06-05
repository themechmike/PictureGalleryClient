using PictureGalleryClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PictureGalleryClient.Services
{
    public class GalleryService : IGalleryService
    {
        string url = "http://localhost:21285";

        HttpClient httpClient = new HttpClient();

        /*
        public async Task<Guid> AddPictureAsync (GalleryItemViewModel GalleryItem)
        {
            GalleryWebApiClient apiClient = new GalleryWebApiClient(url, httpClient);
            GalleryItem.OwnerId = "owner_id";
            GalleryItem.Title = "Title_01";
            Guid returnedValue = await apiClient.PictureAsync(GalleryItem.ToDto());
            return returnedValue;           
        }
        */
        public async Task<GalleryItemViewModel[]> GetGalleryItemsAsync()
        {
            GalleryWebApiClient apiClient = new GalleryWebApiClient(url, httpClient);
            var dtoGalleryItems = await apiClient.PictureAllAsync("user1@dupa.com");
            return dtoGalleryItems.Select(dto => GalleryItemViewModel.FromDto(dto)).ToArray();
        }
    }
}
