using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
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
        public async Task<IActionResult> Index(string sortOrder, int[] selectedGenres, string searchString)
        {
            PopulateGenresCheckboxes(selectedGenres);
            ViewData["MovieSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "date" ? "date_desc" : "date";
            ViewData["CurrentSearch"] = searchString;

            var movies = await _context.Movies.Include(i => i.Images)
                                                .Include(g => g.MovieGenres)
                                                .ThenInclude(mg => mg.Genre)
                                                .ToListAsync();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                movies = movies.Where(i => i.Title.Contains(searchString)).ToList();
            }

            if (selectedGenres.Length > 0)
            {
                movies = movies.Where(m => m.MovieGenres.Any(mg => selectedGenres.Contains(mg.GenreId))).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(m => m.Title).ToList();
                    break;
                case "date":
                    movies = movies.OrderBy(m => m.DateReleased).ToList();
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(m => m.DateReleased).ToList();
                    break;
                default:
                    movies = movies.OrderBy(m => m.Title).ToList();
                    break;
            }

            return View(movies);
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
                .Include(mi => mi.Images)
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
            PopulateGenresCheckboxes();
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

                // create a image list to store the upload files.  
                /*List<MovieImages> images = new List<MovieImages>();
                if (movie.Files != null && movie.Files.Count > 0)
                {
                    foreach (var formFile in movie.Files)
                    {
                        if (formFile.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await formFile.CopyToAsync(memoryStream);
                                // Upload the file if less than 2 MB  
                                if (memoryStream.Length < 2097152)
                                {
                                    //based on the upload file to create Image instance.  
                                    var newImage = new MovieImages()
                                    {
                                        Bytes = memoryStream.ToArray(),
                                        Description = formFile.FileName,
                                        FileExtension = Path.GetExtension(formFile.FileName),
                                        Size = formFile.Length,
                                        Movie = movie,
                                        MovieId = movie.Id

                                    };
                                    //add the image instance to the list.  
                                    images.Add(newImage);
                                }
                                else
                                {
                                    ModelState.AddModelError("File", "The file is too large.");
                                }
                            }
                        }
                    }
                }

                movie.Images = images;
                */
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


            var movie = await _context.Movies
                .Include(mg => mg.MovieGenres)
                .ThenInclude(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            PopulateGenresCheckboxes(movie);


            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, int[] selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieToUpdate = await _context.Movies
                .Include(mg => mg.MovieGenres)
                .ThenInclude(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (await TryUpdateModelAsync<Movies>(movieToUpdate, "", 
                m => m.Title,
                m => m.Director,
                m => m.DateReleased,
                m => m.Description,
                m => m.Runtime,
                m => m.ContentRating,
                m => m.CritiqueScore,
                m => m.Files))
            {
                try
                {
                    UpdateMovieGenres(selectedGenres, movieToUpdate);


                    // create a image list to store the upload files.  
                    /*
                    List<MovieImages> images = new List<MovieImages>();
                    if (movieToUpdate.Files != null && movieToUpdate.Files.Count > 0)
                    {
                        foreach (var formFile in movieToUpdate.Files)
                        {
                            if (formFile.Length > 0)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    await formFile.CopyToAsync(memoryStream);
                                    // Upload the file if less than 2 MB  
                                    if (memoryStream.Length < 2097152)
                                    {
                                        //based on the upload file to create Image instance.  
                                        var newImage = new MovieImages()
                                        {
                                            Bytes = memoryStream.ToArray(),
                                            Description = formFile.FileName,
                                            FileExtension = Path.GetExtension(formFile.FileName),
                                            Size = formFile.Length,
                                            Movie = movieToUpdate,
                                            MovieId = movieToUpdate.Id

                                        };
                                        //add the image instance to the list.  
                                        images.Add(newImage);
                                    }
                                    else
                                    {
                                        ModelState.AddModelError("File", "The file is too large.");
                                    }
                                }
                            }
                        }
                    }

                    movieToUpdate.Images = images;
                    */
                    _context.Update(movieToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movieToUpdate.Id))
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
            //if (ModelState.IsValid && movie != null)
            //{
                
            //}
            return View(movieToUpdate);
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

        //private void PopulateGenresDropDownList(object selectedGenre = null)
        //{
        //    var GenreQuery = from d in _context.Genre
        //                           orderby d.Name
        //                           select d;
        //    ViewBag.Genres = new SelectList(GenreQuery.AsNoTracking(), "Id", "Name", selectedGenre);
        //}

        private void PopulateGenresCheckboxes(Movies? movie = null)
        {
            var allGenres = _context.Genre;
            var selectedMovieGenres = new HashSet<int>();
            
            if ( movie != null && movie.MovieGenres != null)
                selectedMovieGenres = new HashSet<int>(movie.MovieGenres.Select(g => g.GenreId));

            var viewModel = new List<MovieGenreData>();

            foreach (var genre in allGenres) 
            {
                viewModel.Add(new MovieGenreData
                {
                    GenreId = genre.Id,
                    GenreName = genre.Name != null ? genre.Name : "",
                    Selected = selectedMovieGenres.Contains(genre.Id)
                });
            }
            ViewBag.Genres = viewModel;
        }

        private void PopulateGenresCheckboxes(int[] selectedGenres)
        {
            var allGenres = _context.Genre;
            var selectedMovieGenres = new HashSet<int>();

            var viewModel = new List<MovieGenreData>();

            foreach (var genre in allGenres)
            {
                viewModel.Add(new MovieGenreData
                {
                    GenreId = genre.Id,
                    GenreName = genre.Name != null ? genre.Name : "",
                    Selected = selectedGenres.Contains(genre.Id)
                });
            }
            ViewBag.Genres = viewModel;
        }


        private void UpdateMovieGenres(int[] selectedGenres, Movies movie)
        {
            if (selectedGenres == null || movie.MovieGenres == null)
            {
                movie.MovieGenres = new List<MovieGenres>();
            }

            var selectedGenresHS = new HashSet<int>(selectedGenres);
            var movieGenres = new HashSet<int>(movie.MovieGenres.Select(mg => mg.GenreId));

            foreach (var genre in _context.Genre)
            {
                if (selectedGenresHS.Contains(genre.Id))
                {
                    if (!movieGenres.Contains(genre.Id))
                    {
                        movie.MovieGenres.Add(new MovieGenres { GenreId = genre.Id, Genre = genre, Movie = movie, MovieId = movie.Id });
                    }
                }
                else
                {
                    if (movieGenres.Contains(genre.Id))
                    {
                        MovieGenres genreToRemove = movie.MovieGenres.FirstOrDefault(mg => mg.GenreId == genre.Id);
                        _context.Remove(genreToRemove);
                    }
                }
            }

            //movie.MovieGenres = new List<MovieGenres>();

            //if (selectedGenres == null)
            //    return;

            //MovieGenres mg = null;
            //Genre g = null;
            //for(int i = 0; i < selectedGenres.Length; i++)
            //{
            //    mg = new MovieGenres();
            //    g = _context.Genre.Find(selectedGenres[i]);
            //    if (g != null)
            //    {
            //        mg.Genre = g;
            //        mg.GenreId = selectedGenres[i];
            //        mg.MovieId = movie.Id;
            //        mg.Movie = movie;

            //        movie.MovieGenres.Add(mg);
            //    }
            //}

        }

        /*
        public IActionResult GetImage(int id)
        {
            var image = _context.MovieImages.FirstOrDefault(i => i.Id == id);
            if (image == null || image.Bytes == null)
            {
                return NotFound();
            }

            var contentType = !string.IsNullOrEmpty(image.FileExtension)
                ? $"image/{image.FileExtension.TrimStart('.')}"
                : "image/jpeg";

            return File(image.Bytes, contentType);
        }
        */


    }

    public class MovieGenreData
    {
        public int GenreId { get; set; }
        public string? GenreName { get; set; }
        public bool Selected { get; set; }
    }
}
