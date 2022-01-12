using ArtistsMVCDemo.Dtos;
using ArtistsMVCDemo.Models;
using ArtistsMVCDemo.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArtistsMVCDemo.Controllers.Api
{
    public class AlbumsController : ApiController
    {
        private readonly AlbumRepository _albumRepository;

        public AlbumsController()
        {
            _albumRepository = new AlbumRepository();
        }

        public IHttpActionResult GetAlbums()
        {
            return Ok(_albumRepository
                .GetAll()
                .Select(Mapper.Map<Album,AlbumDto>));
        }

        public IHttpActionResult GetAlbum(int id)
        {
            var album = _albumRepository.GetById(id);
            if (album == null)
                return NotFound();
            return Ok(Mapper.Map<Album,AlbumDto>(album));
        }

        [HttpPost]
        public IHttpActionResult CreateAlbum(AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var album = Mapper.Map<AlbumDto, Album>(albumDto);
            _albumRepository.Create(album);
            albumDto.ID = album.ID;
            return Created(new Uri(Request.RequestUri + "/" + album.ID), albumDto);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var albumInDb = _albumRepository.GetById(id);
            if (albumInDb == null)
                return NotFound();
                        
            Mapper.Map(albumDto, albumInDb);
            _albumRepository.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAlbum(int id)
        {
            var albumInDb = _albumRepository.GetById(id);
            if (albumInDb == null)
                return NotFound();
            _albumRepository.Delete(id);
            return Ok(albumInDb);
        }

        [Route("myapi/Albums/GetTwo")]
        public IHttpActionResult GetFirstTwoAlbums()
        {
            return Ok(_albumRepository
                .GetFirstTwo()
                .Select(Mapper.Map<Album, AlbumDto>));
        }

        [Route("api/Albums/GetAllWithArtist")]
        public IHttpActionResult GetAllWithArtist()
        {
            return Ok(_albumRepository
                .GetAllWithArtist()
                .Select(Mapper.Map<Album, AlbumDto>));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _albumRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
