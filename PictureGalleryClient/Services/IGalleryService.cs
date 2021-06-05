using PictureGalleryClient.Models;
using System.Threading.Tasks;

namespace PictureGalleryClient.Services
{
    public interface IGalleryService
    {
        Task<GalleryItemViewModel[]> GetGalleryItemsAsync();
    }
}