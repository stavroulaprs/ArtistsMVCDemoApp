using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtistsMVCDemo.Models
{
    public class Album
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Thumbnail { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public ICollection<Song> Songs { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}