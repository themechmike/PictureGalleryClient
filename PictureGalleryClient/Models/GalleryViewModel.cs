using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureGalleryClient.Models
{
    public class GalleryViewModel
    {
        public GalleryItemViewModel [] GalleryItems { get; set; }
        public UserItemViewModel[] Users { get; set; }

        public GalleryViewModel()
        {
            GalleryItems = new GalleryItemViewModel[0];
            Users = new UserItemViewModel[0];
        }
    }


}
 