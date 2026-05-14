using ht16.Models;
using Microsoft.AspNetCore.Mvc;

namespace ht16.Controllers
{
    public class FilmController : Controller
    {
        private static List<Film> _films = new List<Film>()
        {
            new Film(1, "Cool Film", "Cool Name", "Action", 2006),
            new Film(2, "Funny Film", "Funny Name", "Comedy", 2007),
            new Film(3, "Sad Film", "Sad Name", "Drama", 2008),
            new Film(4, "Even Cooler Film", "Cool Name", "Action", 2007)
        };

        public IActionResult Index(int? searchYear, string searchGenre)
        {
            var films = _films.AsEnumerable();

            if (searchYear.HasValue)
            {
                films = films.Where(f => f.Year == searchYear.Value);
            }

            if (!string.IsNullOrEmpty(searchGenre))
            {
                films = films.Where(f => f.Genre == searchGenre);
            }

            ViewBag.Genres = _films.Select(f => f.Genre).Distinct().ToList();

            ViewBag.CurrentYear = searchYear;
            ViewBag.CurrentGenre = searchGenre;

            return View(films.ToList());
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Film film)
        {
            film.Id = _films.Any() ? _films.Max(f => f.Id) + 1 : 1;
            _films.Add(film);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var film = _films.FirstOrDefault(f => f.Id == id);
            return View(film);
        }

        [HttpPost]
        public IActionResult Edit(Film updFilm)
        {
            var oldFilm = _films.FirstOrDefault(f => f.Id == updFilm.Id);
            if (oldFilm != null)
            {
                oldFilm.Title = updFilm.Title;
                oldFilm.Director = updFilm.Director;
                oldFilm.Genre = updFilm.Genre;
                oldFilm.Year = updFilm.Year;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var film = _films.FirstOrDefault(f => f.Id == id);

            if (film != null) _films.Remove(film);

            return RedirectToAction("Index");
        }
    }
}