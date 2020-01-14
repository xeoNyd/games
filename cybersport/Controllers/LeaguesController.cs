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
    public class LeaguesController : Controller
    {
        private readonly DatabaseContext _context;

        public LeaguesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Leagues
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Leagues.Include(l => l.nameOfGame);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Leagues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues
                .Include(l => l.nameOfGame)
                .FirstOrDefaultAsync(m => m.LeagueID == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        // GET: Leagues/Create
        public IActionResult Create()
        {
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Game_description");
            return View();
        }

        // POST: Leagues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeagueID,Leag_name,Leag_team_num,Leag_Type,prize_pool,NameOfGameID")] League league)
        {
            if (ModelState.IsValid)
            {
                _context.Add(league);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Game_description", league.NameOfGameID);
            return View(league);
        }

        // GET: Leagues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Game_description", league.NameOfGameID);
            return View(league);
        }

        // POST: Leagues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeagueID,Leag_name,Leag_team_num,Leag_Type,prize_pool,NameOfGameID")] League league)
        {
            if (id != league.LeagueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(league);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeagueExists(league.LeagueID))
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
            ViewData["NameOfGameID"] = new SelectList(_context.NameOfGames, "NameOfGameID", "Game_description", league.NameOfGameID);
            return View(league);
        }

        // GET: Leagues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues
                .Include(l => l.nameOfGame)
                .FirstOrDefaultAsync(m => m.LeagueID == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        // POST: Leagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var league = await _context.Leagues.FindAsync(id);
            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeagueExists(int id)
        {
            return _context.Leagues.Any(e => e.LeagueID == id);
        }
    }
}
