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
    public class GamesController : Controller
    {
        private readonly DatabaseContext _context;

        public GamesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Games.Include(g => g.nameOfGame).Include(g => g.team1).Include(g => g.team2);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.nameOfGame)
                .Include(g => g.team1)
                .Include(g => g.team2)
                .FirstOrDefaultAsync(m => m.GameID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Game_description");
            ViewData["Team1ID"] = new SelectList(_context.Teams, "TeamID", "Team_name");
            ViewData["Team2ID"] = new SelectList(_context.Teams, "TeamID", "Team_name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameID,Game_result,NameOfGameID,Team1ID,Team2ID")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Game_description", game.NameOfGameID);
            ViewData["Team1ID"] = new SelectList(_context.Teams, "TeamID", "Team_name", game.Team1ID);
            ViewData["Team2ID"] = new SelectList(_context.Teams, "TeamID", "Team_name", game.Team2ID);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Game_description", game.NameOfGameID);
            ViewData["Team1ID"] = new SelectList(_context.Teams, "TeamID", "Team_name", game.Team1ID);
            ViewData["Team2ID"] = new SelectList(_context.Teams, "TeamID", "Team_name", game.Team2ID);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameID,Game_result,NameOfGameID,Team1ID,Team2ID")] Game game)
        {
            if (id != game.GameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.GameID))
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
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Game_description", game.NameOfGameID);
            ViewData["Team1ID"] = new SelectList(_context.Teams, "TeamID", "Team_name", game.Team1ID);
            ViewData["Team2ID"] = new SelectList(_context.Teams, "TeamID", "Team_name", game.Team2ID);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.nameOfGame)
                .Include(g => g.team1)
                .Include(g => g.team2)
                .FirstOrDefaultAsync(m => m.GameID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameID == id);
        }
    }
}
