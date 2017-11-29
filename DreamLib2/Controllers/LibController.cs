using DreamLib2.Models;
using DreamLib2.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DreamLib2.Controllers
{
    public class LibController : Controller
    {
        private LibraryContext libContext = new LibraryContext();

        // GET: Lib
        public async Task<ActionResult> Index()
        {
            ViewBag.Songs = await libContext.Songs.Include(p => p.Artist).OrderBy(p => p.Name).ToListAsync();
            ViewBag.Artists = await libContext.Artists.OrderByDescending(p => p.Songs.Count).ThenBy(p => p.Name).ToListAsync();
            ViewBag.Genres = await libContext.Genres.OrderBy(p => p.Name).ToListAsync();
            return View();
        }

        // GET: Lib/Details/5
        [HttpGet]
        public ActionResult SongDetails(int? id)
        {
            var song = libContext.Songs.Find(id);
            if(id == null || song == null)
            {
                return RedirectToAction("Index");   /// httpnotfoundresult
            }

            var songDetails = new SongDetails
            {
                Artist = libContext.Artists.Find(song.ArtistId).Name,   //  !!!!
                Name = song.Name,
                Cover = song.Cover,
                Src = song.Src
            };
            return View(songDetails);
        }

        // GET: Lib/Create
        [HttpGet]
        public ActionResult CreateSong()
        {
            return View();
        }

        // POST: Lib/Create
        [HttpPost]
        public ActionResult CreateSong(SongEdit newSong)
        {
            if(ModelState.IsValid)
            {
                var song = libContext.Songs.FirstOrDefault(p => p.Name == newSong.Name);
                if (song != null)   // if song exists
                {
                    return View("CreateSong");
                }

                var artist = libContext.Artists.FirstOrDefault(p => p.Name == newSong.Artist);
                if(artist == null) // if artist is not exist
                {
                    artist = libContext.Artists.Add(
                        new Artist
                        {
                            Name = newSong.Artist                            
                        });
                }

                var genre = libContext.Genres.FirstOrDefault(p => p.Name == newSong.Genre);
                if(genre == null)   //  if genre is not exist
                {
                    genre = libContext.Genres.Add(
                        new Genre
                        {
                            Name = newSong.Genre
                        });
                    
                }

                libContext.Songs.Add(
                    new Song
                    {
                        Name = newSong.Name,
                        Cover = newSong.Cover,
                        CreatedDate = DateTime.Now,
                        Src = newSong.Src,
                        ArtistId = artist.Id,
                    });

                //Adding info at GenreSongs

                libContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Lib/Edit/5
        public ActionResult EditSong(int? id)
        {
                       
            return RedirectToAction("Index");
        }

        // POST: Lib/Edit/5
        [HttpPost]
        public ActionResult EditSong(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lib/Delete/5
        [HttpDelete]
        public ActionResult DeleteSong(int? id)
        {
            var song = libContext.Songs.Find(id);
            if (id == null || song == null)
            {
                return RedirectToAction("Index");
            }

            libContext.Songs.Remove(song);
            libContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
