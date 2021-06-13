using Microsoft.AspNetCore.Http;
using PictureGalleryClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PictureGalleryClient.Models
{
    public class GalleryItemViewModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateAdded { get; set; }

        [Required]
        public string Title { get; set; }
        public string Url { get; set; }
        public Guid OwnerId { get; set; }
        public IFormFile File { get; set; }

        internal PictureDTO ToDto()
        {
            PictureDTO returnValue = new PictureDTO();

            returnValue.OwnerId = OwnerId;
            returnValue.Title = Title;
            returnValue.Url = Url;
            // returnValue.File = File;

            return returnValue;
        }

        internal static GalleryItemViewModel FromDto(Picture picture)
        {
            GalleryItemViewModel returnedValue = new GalleryItemViewModel();

            returnedValue.Id = picture.Id;
            returnedValue.DateAdded = picture.DateAdded;
            returnedValue.OwnerId = picture.OwnerId;
            returnedValue.Title = picture.Title;
            returnedValue.Url = picture.Url;

            return returnedValue;
        }
    }
}
