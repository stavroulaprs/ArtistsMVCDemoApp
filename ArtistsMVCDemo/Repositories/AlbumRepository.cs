using ArtistsMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ArtistsMVCDemo.Repositories
{
    public class AlbumRepository : IAlbumData
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums
                .ToList();
        }

        public Album GetById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.Albums
                .SingleOrDefault(a => a.ID == id);
        }

        public void Create(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public void Update(Album album)
        {
            _context.Entry(album).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            Album album = GetById(id);
            _context.Albums.Remove(album);
            _context.SaveChanges();
        }

        public IEnumerable<Album> GetAllWithArtist()
        {
            var albums = _context.Albums
                .Include(s => s.Artist)
                .ToList();

            return albums;
        }

        public Album GetByIdWithArtist(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.Albums
                .Include(a => a.Artist)
                .SingleOrDefault(a => a.ID == id);
        }
        public IEnumerable<Album> GetFirstTwo()
        {
            var albums =  _context.Albums.Take(2).ToList();

            return albums;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}