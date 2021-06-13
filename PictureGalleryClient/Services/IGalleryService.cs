using PictureGalleryClient.Models;
using System;
using System.Threading.Tasks;

namespace PictureGalleryClient.Services
{
    public interface IGalleryService
    {
        Task<GalleryItemViewModel[]> GetGalleryItemsAsync(string ownerId);
        Task<UserItemViewModel[]> CheckUser();
        Task<Guid> AddUserAsync(UserDTO user);
        Task<Guid> AddPictureAsync(GalleryItemViewModel galleryItem, string ownerId);
    }
}