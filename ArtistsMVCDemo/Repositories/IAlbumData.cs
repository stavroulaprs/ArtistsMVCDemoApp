using ArtistsMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistsMVCDemo.Repositories
{
    public interface IAlbumData : IDisposable
    {
        IEnumerable<Album> GetAll();
        Album GetById(int? id);
        void Create(Album album);
        void Update(Album album);
        void Delete(int? id);
    }
}