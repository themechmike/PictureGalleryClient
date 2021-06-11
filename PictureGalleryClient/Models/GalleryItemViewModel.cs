﻿using PictureGalleryClient.Services;
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

        internal PictureDTO ToDto()
        {
            PictureDTO returnValue = new PictureDTO();

            returnValue.OwnerId = OwnerId;
            returnValue.Title = Title;
            returnValue.Url = Url;

            return returnValue;
        }

        internal static GalleryItemViewModel FromDto(Picture dto)
        {
            GalleryItemViewModel returnedValue = new GalleryItemViewModel();

            returnedValue.Id = dto.Id;
            returnedValue.DateAdded = dto.DateAdded;
            returnedValue.OwnerId = dto.OwnerId;
            returnedValue.Title = dto.Title;
            returnedValue.Url = dto.Url;

            return returnedValue;
        }
    }
}
