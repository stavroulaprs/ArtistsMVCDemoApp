using ArtistsMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistsMVCDemo.ViewModels
{
    public class AlbumFormViewModel
    {
        public Album Album { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
    }
}