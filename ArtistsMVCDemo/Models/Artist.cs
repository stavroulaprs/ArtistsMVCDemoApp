﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtistsMVCDemo.Models
{
    public class Artist
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "LastName is required")]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }

        public string Thumbnail { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [NotMapped]
        public string FullName 
        {
            get => $"{FirstName} {LastName}";
        }

        public ICollection<Album> Albums { get; set; }
    }
}