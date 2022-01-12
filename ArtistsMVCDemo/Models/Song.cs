using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtistsMVCDemo.Models
{
    public class Song
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Title is required")]
        [StringLength(255, MinimumLength = 3)]
        public string Title { get; set; }

        public string Youtube { get; set; }

        [ForeignKey("Album")]
        [Display(Name = "Album")]
        public int AlbumId { get; set; }

        public Album Album { get; set; }

    }
}