using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDataBase.Data;
using MovieDataBase.Models;
using MovieDataBase.Services;

namespace MovieDataBase.Controllers
{
    public class PeopleController : Controller
    {
        private readonly MovieDataBaseContext _context;
        private readonly SupabaseStorageService _storageService;

        public PeopleController(MovieDataBaseContext context, SupabaseStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            return View(await _context.People.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People
                .Include(p => p.MovieRoles!)
                    .ThenInclude(pr => pr.Role)
                .Include(p => p.MovieRoles!)
                    .ThenInclude(pr => pr.Movie!)
                        .ThenInclude(m => m.Images)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (people == null)
            {
                return NotFound();
            }

            // Preencher FullUrl para imagens dos filmes associados (se existirem)
            if (people.MovieRoles != null)
            {
                foreach (var pr in people.MovieRoles)
                {
                    var movie = pr.Movie;
                    if (movie?.Images != null)
                    {
                        foreach (var image in movie.Images)
                        {
                            if (image.imageUrl == null) continue;
                            image.FullUrl = _storageService.GetPublicUrl(image.imageUrl);
                        }
                    }
                }
            }

            if (people.Images != null)
            {
                foreach (var image in people.Images)
                {
                    if (image.imageUrl == null) continue;
                    image.FullUrl = _storageService.GetPublicUrl(image.imageUrl);
                }
            }

            return View(people);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateOfBirth,DateOfDeath,Biography,Height")] People people)
        {
            if (ModelState.IsValid)
            {
                _context.Add(people);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(people);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateOfBirth,DateOfDeath,Biography,Height")] People people)
        {
            if (id != people.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(people);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleExists(people.Id))
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
            return View(people);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People
                .FirstOrDefaultAsync(m => m.Id == id);
            if (people == null)
            {
                return NotFound();
            }

            return View(people);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var people = await _context.People.FindAsync(id);
            if (people != null)
            {
                _context.People.Remove(people);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
