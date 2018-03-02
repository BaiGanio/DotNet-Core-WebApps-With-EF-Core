using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITGigs.DB;
using ITGigs.ITGigService.Domain.Models;

namespace ITGigs.WebApp.Controllers
{
    public class ITGigsController : Controller
    {
        private readonly AppDbContext _context;
        private bool _isSignedIn;
        public ITGigsController(AppDbContext context)
        {
            _context = context;
            _isSignedIn = true;// HttpContext.Session.GetObjectFromJson<string>("IsSignedIn");      
        }

        // GET: ITGigs
        public async Task<IActionResult> Index()
        {
            ViewData["IsSignedIn"] = _isSignedIn;
            var appDbContext = _context.ITGigs.Include(i => i.Performer).Include(i => i.Venue);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ITGigs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTGig = await _context.ITGigs
                .Include(i => i.Performer)
                .Include(i => i.Venue)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iTGig == null)
            {
                return NotFound();
            }

            return View(iTGig);
        }

        // GET: ITGigs/Create
        public IActionResult Create()
        {
            ViewData["PerformerId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["VenueId"] = new SelectList(_context.Venues, "Name", "Name");
            return View();
        }

        // POST: ITGigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PerformerId,VenueId,ImgUrl,TicketPrice")] ITGig iTGig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iTGig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerformerId"] = new SelectList(_context.Users, "Id", "Id", iTGig.PerformerId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "Name", "Name", iTGig.Venue.Name);
            return View(iTGig);
        }

        // GET: ITGigs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTGig = await _context.ITGigs.SingleOrDefaultAsync(m => m.Id == id);
            if (iTGig == null)
            {
                return NotFound();
            }
            ViewData["PerformerId"] = new SelectList(_context.Users, "Id", "Id", iTGig.PerformerId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Id", iTGig.VenueId);
            return View(iTGig);
        }

        // POST: ITGigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,PerformerId,VenueId,ImgUrl,TicketPrice")] ITGig iTGig)
        {
            if (id != iTGig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iTGig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ITGigExists(iTGig.Id))
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
            ViewData["PerformerId"] = new SelectList(_context.Users, "Id", "Id", iTGig.PerformerId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Id", iTGig.VenueId);
            return View(iTGig);
        }

        // GET: ITGigs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTGig = await _context.ITGigs
                .Include(i => i.Performer)
                .Include(i => i.Venue)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iTGig == null)
            {
                return NotFound();
            }

            return View(iTGig);
        }

        // POST: ITGigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var iTGig = await _context.ITGigs.SingleOrDefaultAsync(m => m.Id == id);
            _context.ITGigs.Remove(iTGig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ITGigExists(string id)
        {
            return _context.ITGigs.Any(e => e.Id == id);
        }
    }
}
