using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MovieDataBase.Data;
using MovieDataBase.Models;
using MovieDataBase.Services;

namespace MovieDataBase.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDataBaseContext _context;
        private readonly IStorageService _storageService;

        public MoviesController(MovieDataBaseContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string sortOrder, int[] selectedGenres, string searchString)
        {
            PopulateGenresCheckboxes(selectedGenres);
            ViewData["MovieSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "date" ? "date_desc" : "date";
            ViewData["CurrentSearch"] = searchString;

            // Query base
            var query = _context.Movies
                .Include(m => m.Images.Where(i => i.IsMoviePoster == true)) // Filtra posters no EF Core 5+
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .AsQueryable();

            // Filtro de pesquisa
            if (!String.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(m => m.Title != null && m.Title.Contains(searchString));
            }

            // Filtro de géneros
            if (selectedGenres.Length > 0)
            {
                query = query.Where(m => m.MovieGenres != null && m.MovieGenres.Any(mg => selectedGenres.Contains(mg.GenreId)));
            }

            // Ordenação
            query = sortOrder switch
            {
                "name_desc" => query.OrderByDescending(m => m.Title),
                "date" => query.OrderBy(m => m.DateReleased),
                "date_desc" => query.OrderByDescending(m => m.DateReleased),
                _ => query.OrderBy(m => m.Title)
            };

            // Executa a query
            var movies = await query.ToListAsync();

            // Adiciona URLs completas aos posters
            foreach (var movie in movies)
            {
                if (movie.Images?.Any() == true)
                {
                    foreach (var image in movie.Images) // Já só tem posters devido ao Include filtrado
                    {
                        if (!string.IsNullOrEmpty(image.imageUrl))
                        {
                            image.FullUrl = _storageService.GetFullUrl(image.imageUrl);
                        }
                    }
                }
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
                .Include(mg => mg.MovieGenres!)
                .ThenInclude(g => g.Genre)
                .Include(mi => mi.Images)
                .Include(pm => pm.PeopleRoles!)
                .ThenInclude(p => p.People)
                .Include(pm => pm.PeopleRoles!)
                .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            // Adicionar URLs completas às imagens
            if (movie.Images != null)
            {
                foreach (var image in movie.Images)
                {
                    if (image.imageUrl == null) continue;
                    image.FullUrl = _storageService.GetFullUrl(image.imageUrl);
                }
            }


            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            PopulateGenresCheckboxes();
            PopulateContentRatings();
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

                
                // Criar a lista de imagens a partir dos ficheiros enviados
                var newImages = await CreateImageListFromFiles(movie);
                movie.Images = newImages;
                  
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // repopula selects se houver erro
            PopulateGenresCheckboxes(movie);
            PopulateContentRatings(movie);
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
            PopulateContentRatings(movie);

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
                .Include(m => m.Images) // Incluir imagens existentes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movieToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Movies>(
                movieToUpdate, 
                "", 
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

                    // Criar a lista de novas imagens a partir dos ficheiros enviados
                    var newImages = await CreateImageListFromFiles(movieToUpdate);
                    if (newImages != null && newImages.Count > 0)
                    {

                        // Adicionar novas imagens à lista existente
                        if (movieToUpdate.Images == null)
                        {
                            movieToUpdate.Images = new List<MovieImages>();
                        }

                        foreach (var image in newImages)
                        {
                            movieToUpdate.Images.Add(image);
                        }
                    }

                    if (ModelState.IsValid)
                    {
                        _context.Update(movieToUpdate);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
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
            }

            // repopula selects antes de devolver a view em caso de falha
            PopulateGenresCheckboxes(movieToUpdate);
            PopulateContentRatings(movieToUpdate);
            return View(movieToUpdate);
        }


        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Incluir as imagens na query
            var movie = await _context.Movies
                .Include(m => m.Images)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie != null)
            {
                // Deletar todas as imagens do MinIO/Supabase
                if (movie.Images != null && movie.Images.Any())
                {
                    foreach (var image in movie.Images)
                    {
                        try
                        {
                            await _storageService.DeleteImageAsync(image.imageUrl);
                        }
                        catch (Exception ex)
                        {
                            // Log do erro mas continua a deletar as outras
                            // Podes usar ILogger aqui se tiveres configurado
                            Console.WriteLine($"Erro ao deletar imagem {image.imageUrl}: {ex.Message}");
                        }
                    }
                }

                // Remover o filme (as imagens serão removidas em cascata do BD)
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        private void PopulateGenresCheckboxes(Movies? movie = null)
        {
            var allGenres = _context.Genre;
            var selectedMovieGenres = new HashSet<int>();

            if (movie != null && movie.MovieGenres != null)
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

        [HttpGet]
        public async Task<IActionResult> GetImageUrl(int id)
        {
            var image = await _context.MovieImages.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }
            
            // Converte o caminho relativo em URL completo
            var fullUrl = _storageService.GetFullUrl(image.imageUrl);

            return Ok(new { url = fullUrl });
        }

        private async Task<List<MovieImages>> CreateImageListFromFiles(Movies movie)
        {
            // create a image list to store the upload files.  
            // Upload de novas imagens para MinIO/Supabase
            if (movie.Files != null && movie.Files.Count > 0)
            {
                List<MovieImages> newImages = new List<MovieImages>();

                foreach (var formFile in movie.Files)
                {
                    if (formFile.Length > 0)
                    {
                        // Validar tamanho (2MB)
                        if (formFile.Length > 2097152)
                        {
                            ModelState.AddModelError("Files", $"O arquivo {formFile.FileName} é muito grande. Máximo 2MB.");
                            continue;
                        }

                        // Validar tipo de arquivo
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                        var extension = Path.GetExtension(formFile.FileName).ToLowerInvariant();

                        if (!allowedExtensions.Contains(extension))
                        {
                            ModelState.AddModelError("Files", $"Tipo de arquivo não permitido: {extension}");
                            continue;
                        }

                        try
                        {
                            // Upload para MinIO/Supabase e obter URL
                            var imageUrl = await _storageService.UploadImageAsync(formFile);

                            // Criar registro da imagem
                            var newImage = new MovieImages
                            {
                                imageUrl = imageUrl,
                                Movie = movie,
                                MovieId = movie.Id
                            };

                            newImages.Add(newImage);
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("Files", $"Erro ao fazer upload de {formFile.FileName}: {ex.Message}");
                        }
                    }
                }

                return newImages;
            }

            return new List<MovieImages>();
        }

        private void PopulateContentRatings(Movies? movie = null)
        {
            var values = Enum.GetValues(typeof(ContentRating)).Cast<ContentRating>();
            var items = values.Select(v => new SelectListItem
            {
                Value = v.ToString(),
                Text = MovieDataBase.Models.EnumHelpers.GetDisplayName(v)
            }).ToList();

            var selectedValue = movie?.ContentRating?.ToString();
            ViewBag.ContentRatings = new SelectList(items, "Value", "Text", selectedValue);
        }
    }

    public class MovieGenreData
    {
        public int GenreId { get; set; }
        public string? GenreName { get; set; }
        public bool Selected { get; set; }
    }
    
}
