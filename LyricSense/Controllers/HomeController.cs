using LyricSense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace LyricSense.Controllers
{
    public class HomeController : Controller
    {
        readonly LyricsContext db;
        public HomeController(LyricsContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult SearchResult(string searchString)
        {
            SongListViewModel model = new()
            {
                Songs = db.Songs
                    .Where(Songs => Songs.Lyrics.Contains(searchString))
            };
            return View(model);
        }
        public ViewResult Lyrics(int Id)
        {
            SongListViewModel model = new()
            {
                Songs = db.Songs
                    .Where(Songs => Songs.Id == Id)
            };
            return View(model);
        }

        public ViewResult Artist(string Artist)
        {
            SongListViewModel model = new()
            {
                Songs = db.Songs
                    .Where(Songs => Songs.Artist == Artist)
            };
            return View(model);
        }

        public ViewResult Album(string Album)
        {
            SongListViewModel model = new()
            {
                Songs = db.Songs
                    .Where(Songs => Songs.Album == Album)
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}