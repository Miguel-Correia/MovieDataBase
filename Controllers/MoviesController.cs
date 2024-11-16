using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDataBase.Data;
using MovieDataBase.Models;

namespace MovieDataBase.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDataBaseContext _context;

        public MoviesController(MovieDataBaseContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.Include(i => i.Images)
                                                .Include(g => g.MovieGenres)
                                                .ThenInclude(mg => mg.Genre)
                                                .ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(mg => mg.MovieGenres)
                .ThenInclude(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            PopulateGenresDropDownList();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movies movie, int[] selectedGenres)
        {
            
            if (ModelState.IsValid)
            {
                UpdateMovieGenres(selectedGenres, movie);

                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PopulateGenresDropDownList();

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movies movie, int[] selectedGenres)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UpdateMovieGenres(selectedGenres, movie);

                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        private void PopulateGenresDropDownList(object selectedGenre = null)
        {
            var GenreQuery = from d in _context.Genre
                                   orderby d.Name
                                   select d;
            ViewBag.Genres = new SelectList(GenreQuery.AsNoTracking(), "Id", "Name", selectedGenre);
        }

        private void UpdateMovieGenres(int[] selectedGenres, Movies movie)
        {
            movie.MovieGenres = new List<MovieGenres>();

            if (selectedGenres == null)
                return;

            MovieGenres mg = null;
            Genre g = null;
            for(int i = 0; i < selectedGenres.Length; i++)
            {
                mg = new MovieGenres();
                g = _context.Genre.Find(selectedGenres[i]);
                if (g != null)
                {
                    mg.Genre = g;
                    mg.GenreId = selectedGenres[i];
                    mg.MovieId = movie.Id;
                    mg.Movie = movie;

                    movie.MovieGenres.Add(mg);
                }
            }

        }

    }
}
