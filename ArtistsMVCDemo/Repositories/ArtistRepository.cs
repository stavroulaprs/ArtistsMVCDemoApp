using ArtistsMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ArtistsMVCDemo.Repositories
{
    public class ArtistRepository : IArtistData
    {
        private ApplicationDbContext _context;

        public ArtistRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Artist> GetAll()
        {
           return _context.Artists.ToList();
        }

        public IEnumerable<Artist> GetAllWithAlbums()
        {
            return _context.Artists.Include(a => a.Albums);
        }

        public Artist GetById(int? id)
        {
            return _context.Artists
                .FirstOrDefault(a => a.ID == id);
        }

        public Artist GetByIdWithAlbums(int? id)
        {
            return _context.Artists
                    .Include(a => a.Albums)
                    .FirstOrDefault(a => a.ID == id);
        }

        public void Create(Artist artist)
        {
            _context.Artists.Add(artist);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            _context.Artists.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void Update(Artist artist)
        {
            _context.Entry(artist).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}