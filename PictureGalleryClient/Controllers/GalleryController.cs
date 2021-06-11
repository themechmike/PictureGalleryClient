using PictureGalleryClient.Models;
using PictureGalleryClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System;

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

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserItemViewModel user)
        {
            Guid guid = await _galleryService.AddUserAsync(user);
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPicture(GalleryItemViewModel picture)
        {
            Guid guid = await _galleryService.AddPictureAsync(picture);
            return RedirectToAction("Index");
        }
    }
} 