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
    public class PlayingGamesController : Controller
    {
        private readonly DatabaseContext _context;

        public PlayingGamesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: PlayingGames
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.PlayingGames.Include(p => p.nameOfGame).Include(p => p.team);
            return View(await databaseContext.ToListAsync());
        }

        // GET: PlayingGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playingGame = await _context.PlayingGames
                .Include(p => p.nameOfGame)
                .Include(p => p.team)
                .FirstOrDefaultAsync(m => m.PlayingGameID == id);
            if (playingGame == null)
            {
                return NotFound();
            }

            return View(playingGame);
        }

        // GET: PlayingGames/Create
        public IActionResult Create()
        {
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Name_of_Game");
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "Team_name");
            return View();
        }

        // POST: PlayingGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayingGameID,NameOfGameID,TeamID")] PlayingGame playingGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playingGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Name_of_Game", playingGame.NameOfGameID);
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "Team_name", playingGame.TeamID);
            return View(playingGame);
        }

        // GET: PlayingGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playingGame = await _context.PlayingGames.FindAsync(id);
            if (playingGame == null)
            {
                return NotFound();
            }
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Name_of_Game", playingGame.NameOfGameID);
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "Team_name", playingGame.TeamID);
            return View(playingGame);
        }

        // POST: PlayingGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayingGameID,NameOfGameID,TeamID")] PlayingGame playingGame)
        {
            if (id != playingGame.PlayingGameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playingGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayingGameExists(playingGame.PlayingGameID))
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
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Game_description", playingGame.NameOfGameID);
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "Team_name", playingGame.TeamID);
            return View(playingGame);
        }

        // GET: PlayingGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playingGame = await _context.PlayingGames
                .Include(p => p.nameOfGame)
                .Include(p => p.team)
                .FirstOrDefaultAsync(m => m.PlayingGameID == id);
            if (playingGame == null)
            {
                return NotFound();
            }

            return View(playingGame);
        }

        // POST: PlayingGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playingGame = await _context.PlayingGames.FindAsync(id);
            _context.PlayingGames.Remove(playingGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayingGameExists(int id)
        {
            return _context.PlayingGames.Any(e => e.PlayingGameID == id);
        }
    }
}
