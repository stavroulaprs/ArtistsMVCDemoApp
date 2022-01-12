using ArtistsMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using ArtistsMVCDemo.ViewModels;

namespace ArtistsMVCDemo.Controllers
{
    [Authorize]
    public class SongsController : Controller
    {
        private ApplicationDbContext _context;

        public SongsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Songs
        public ActionResult Index()
        {
            var songs = _context
                .Songs
                .Include(s => s.Album.Artist);

            return View(songs);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var song = _context
                .Songs
                .Include(s => s.Album.Artist)
                .SingleOrDefault(s => s.ID == id);

            if (song == null)
            {
                return HttpNotFound();
            }

            return View(song);
        }

        public ActionResult New()
        {
            //Get albums from database
            var albums = _context.Albums.ToList();

            // Init and fill the viewmodel
            var viewModel = new SongFormViewModel()
            {
                Song = new Song(),
                Albums = albums
            };

            //Return the apropriate view with the viewmodel
            return View("SongForm", viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var song = _context.Songs
                .Include(s => s.Album)
                .SingleOrDefault(s => s.ID == id);

            if (song == null)
            {
                return HttpNotFound();
            }

            var albums = _context.Albums.ToList();

            var viewModel = new SongFormViewModel()
            {
                Song = song,
                Albums = albums
            };

            return View("SongForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Song song)
        {

            song.Youtube = $"https://www.youtube.com/embed/{song.Youtube}";
            if (song.ID == 0)
            {

                _context.Songs.Add(song);
            }
            else
            {
                var songInDb = _context.Songs.Single(s => s.ID == song.ID);
                songInDb.Title = song.Title;
                songInDb.Youtube = song.Youtube;
                songInDb.AlbumId = song.AlbumId;
            }

            if (!ModelState.IsValid)
            {
                var viewModel = new SongFormViewModel()
                {
                    Song = song,
                    Albums = _context.Albums.ToList()
                };

                return View("SongForm", viewModel);
            }
            else
            {
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Songs");
        }
        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var song = _context.Songs
                .Include(s => s.Album)
                .SingleOrDefault(s => s.ID == id);

            if (song == null)
            {
                return HttpNotFound();
            }

            return View(song);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var song = _context.Songs
                .Include(s => s.Album)
                .SingleOrDefault(s => s.ID == id);

            _context.Songs.Remove(song);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}