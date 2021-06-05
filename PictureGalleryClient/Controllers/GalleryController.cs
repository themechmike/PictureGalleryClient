using PictureGalleryClient.Models;
using PictureGalleryClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace PictureGalleryClient.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        public async Task<IActionResult> Index()
        {
            var galleryItems = await _galleryService.GetGalleryItemsAsync();
            var galleryModel = new GalleryViewModel()
            {
                GalleryItems = galleryItems
            };

            return View(galleryModel);
        }
    }
} 