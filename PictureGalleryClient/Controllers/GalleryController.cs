using PictureGalleryClient.Models;
using PictureGalleryClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using AuthDatabase.Entities;
using System.Linq;

namespace PictureGalleryClient.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly UserManager<AppUser> _userManager;

        public GalleryController(IGalleryService galleryService, UserManager<AppUser> userManager)
        {
            _galleryService = galleryService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Challenge();
            }

            var allUsersOnServer = await _galleryService.CheckUser();
            var user = allUsersOnServer.Where(e => e.UserEmail == currentUser.Email).FirstOrDefault();
            if (user == null)
            {
                UserItemViewModel newUser = new UserItemViewModel();
                newUser.UserEmail = currentUser.Email;

                var userAdded = await _galleryService.AddUserAsync(newUser.ToDto());
            }

            var galleryItems = await _galleryService.GetGalleryItemsAsync(currentUser.Email);
            
            var galleryModel = new GalleryViewModel()
            {
                GalleryItems = galleryItems
            };

            return View(galleryModel);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPicture(GalleryItemViewModel picture)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Challenge();
            }
            await _galleryService.AddPictureAsync(picture, currentUser.Email);

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePicture(Guid pictureId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Challenge();
            }
            await _galleryService.DeletePictureAsync(currentUser.Email, pictureId);

            return RedirectToAction("Index");
        }
    }
} 