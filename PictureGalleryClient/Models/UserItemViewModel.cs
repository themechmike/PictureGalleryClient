using PictureGalleryClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PictureGalleryClient.Models
{
    public class UserItemViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string userEmail { get; set; }

        internal UserDTO ToDto()
        {
            {
                UserDTO returnValue = new UserDTO();
                returnValue.Email = userEmail;
                return returnValue;
            }
        }
    }
}
