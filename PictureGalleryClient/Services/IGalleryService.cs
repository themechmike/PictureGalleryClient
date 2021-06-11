using PictureGalleryClient.Models;
using System;
using System.Threading.Tasks;

namespace PictureGalleryClient.Services
{
    public interface IGalleryService
    {
        Task<GalleryItemViewModel[]> GetGalleryItemsAsync();
        Task<Guid> AddUserAsync(UserItemViewModel user);
        Task<Guid> AddPictureAsync(GalleryItemViewModel galleryItem);
    }
}