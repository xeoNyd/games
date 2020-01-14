using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cybersport.Data;
using cybersport.Models;
using Microsoft.AspNetCore.Authorization;

namespace cybersport.Controllers
{
    [Authorize]
    public class NameOfGamesController : Controller
    {
        private readonly DatabaseContext _context;

        public NameOfGamesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: NameOfGames
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.NameOfGames.Include(n => n.genre);
            return View(await databaseContext.ToListAsync());
        }
        [HttpPost]
        public JsonResult suchNameOfGameAlreadyExist(string name_of_game)
        {
            return Json(!_context.NameOfGames.Any(nameofgame => nameofgame.Name_of_Game == name_of_game));
        }
        // GET: NameOfGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nameOfGame = await _context.NameOfGames
                .Include(n => n.genre)
                .FirstOrDefaultAsync(m => m.NameOfGameID == id);
            if (nameOfGame == null)
            {
                return NotFound();
            }

            return View(nameOfGame);
        }

        // GET: NameOfGames/Create
        public IActionResult Create()
        {
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Genre_name");
            return View();
        }

        // POST: NameOfGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameOfGameID,Name_of_Game,Game_description,GenreID")] NameOfGame nameOfGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nameOfGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Genre_name", nameOfGame.GenreID);
            return View(nameOfGame);
        }

        // GET: NameOfGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nameOfGame = await _context.NameOfGames.FindAsync(id);
            if (nameOfGame == null)
            {
                return NotFound();
            }
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Genre_name", nameOfGame.GenreID);
            return View(nameOfGame);
        }

        // POST: NameOfGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NameOfGameID,Name_of_Game,Game_description,GenreID")] NameOfGame nameOfGame)
        {
            if (id != nameOfGame.NameOfGameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nameOfGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NameOfGameExists(nameOfGame.NameOfGameID))
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
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Genre_description", nameOfGame.GenreID);
            return View(nameOfGame);
        }

        // GET: NameOfGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nameOfGame = await _context.NameOfGames
                .Include(n => n.genre)
                .FirstOrDefaultAsync(m => m.NameOfGameID == id);
            if (nameOfGame == null)
            {
                return NotFound();
            }

            return View(nameOfGame);
        }

        // POST: NameOfGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nameOfGame = await _context.NameOfGames.FindAsync(id);
            _context.NameOfGames.Remove(nameOfGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NameOfGameExists(int id)
        {
            return _context.NameOfGames.Any(e => e.NameOfGameID == id);
        }
    }
}
