using ArtistsMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtistsMVCDemo.Dtos
{
    public class AlbumDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}