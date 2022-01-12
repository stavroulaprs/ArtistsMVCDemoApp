using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtistsMVCDemo.Dtos
{
    public class ArtistDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "LastName is required")]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
    }
}