using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtistsMVCDemo.Models;
using ArtistsMVCDemo.Repositories;
using ArtistsMVCDemo.ViewModels;

namespace ArtistsMVCDemo.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IAlbumData _albumRepository;
        private readonly IArtistData _artistRepository;
        private readonly AlbumRepository _albumAdditionalMethods;

        public AlbumsController()
        {
            _albumRepository = new AlbumRepository();
            _artistRepository = new ArtistRepository();
            _albumAdditionalMethods = new AlbumRepository();
        }

        // GET: Albums
        public ActionResult Index()
        {
            var albums = _albumAdditionalMethods.GetAllWithArtist();
            return View(albums);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = _albumRepository.GetById(id);

            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            //ViewBag.ArtistId = new SelectList(db.Artists, "ID", "FullName");
            var artists = _artistRepository.GetAll();
            var viewModel = new AlbumFormViewModel()
            {
                Album = new Album(),
                Artists = artists
            };
            return View(viewModel);
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if(ImageFile == null)
                {
                    album.Thumbnail = "na_image.jpg";
                }
                else
                {
                    album.Thumbnail = Path.GetFileName(ImageFile.FileName);
                    string fileName = Path.Combine(Server.MapPath("~/img/"), album.Thumbnail);
                    ImageFile.SaveAs(fileName);
                }
                _albumRepository.Create(album);
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(_artistRepository.GetAll(), "ID", "FullName", album.ArtistId);
            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = _albumRepository.GetById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(_artistRepository.GetAll(), "ID", "FullName", album.ArtistId);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                album.Thumbnail = Path.GetFileName(album.ImageFile.FileName);
                string fileName = Path.Combine(Server.MapPath("~/img/"), album.Thumbnail);
                album.ImageFile.SaveAs(fileName);

                _albumRepository.Update(album);
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(_artistRepository.GetAll(), "ID", "FullName", album.ArtistId);
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = _albumRepository.GetById(id);

            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _albumRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _albumRepository.Dispose();
                _artistRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
