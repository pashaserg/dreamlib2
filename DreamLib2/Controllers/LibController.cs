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
            ViewBag.Top10Songs = libContext.Songs.OrderBy(p => p.Name).Take(10).Include(p => p.Artist);
            ViewBag.Top10Artists = libContext.Artists.OrderByDescending(p => p.Songs.Count).ThenBy(p => p.Name).Take(10);
            ViewBag.Top10Genres = libContext.Genres.OrderBy(p => p.Name).Take(10);
            return View();
        }

        // GET: Lib/Details/5
        [HttpGet]
        public ActionResult SongDetails(int id)
        {
            return View();
        }

        // GET: Lib/Create
        [HttpGet]
        public ActionResult CreateSong()
        {
            return View();
        }

        // POST: Lib/Create
        [HttpPost]
        public ActionResult CreateSong(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lib/Edit/5
        public ActionResult EditSong(int id)
        {
            return View();
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
        public ActionResult DeleteSong(int id)
        {
            return View();
        }

        // POST: Lib/Delete/5
        [HttpPost]
        public ActionResult DeleteSong(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
