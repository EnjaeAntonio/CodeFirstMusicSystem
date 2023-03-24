using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstMusicSystem.Data;
using CodeFirstMusicSystem.Models;
using CodeFirstMusicSystem.Models.Viewmodel;

namespace CodeFirstMusicSystem.Controllers
{
    public class PodcastsController : Controller
    {
        private readonly MusicSystemContext _context;

        public PodcastsController(MusicSystemContext context)
        {
            _context = context;
        }

        // GET: Podcasts
        public async Task<IActionResult> Index()
        {
              return _context.Podcast != null ? 
                          View(await _context.Podcast.ToListAsync()) :
                          Problem("Entity set 'MusicSystemContext.Podcast'  is null.");
        }

        // GET: Podcasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast
                .Include(p => p.Episodes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcast == null)
            {
                return NotFound();
            }

            podcast.Episodes = podcast.Episodes.OrderByDescending(e => e.AirDate).ToList();

            PodcastEpisodeViewModel viewModel = new PodcastEpisodeViewModel
            {
                SelectedEpisodeId = 0,
                Podcast = podcast,
                Episodes = podcast.Episodes
            };

            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Details(int id, PodcastEpisodeViewModel viewModel)
        {
            if (id != viewModel.SelectedEpisodeId)
            {
                return NotFound();
            }

            var selectedEpisode = _context.Episode.FirstOrDefault(e => e.Id == viewModel.SelectedEpisodeId);

            if (selectedEpisode == null)
            {
                return NotFound();
            }

            // Do something with the selected episode

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddToListenerList(int podcastId)
        {
            // Get the podcast by its Id
            var podcast = _context.Podcast.FirstOrDefault(p => p.Id == podcastId);

            if (podcast == null)
            {
                return NotFound();
            }

            // Get all listener lists
            var allListenerLists = _context.ListenerList.ToList();

            var existingListenerLists = _context.PodcastListenerLists
                .Where(pll => pll.PodcastId == podcastId)
                .Select(pll => pll.ListenerListId)
                .ToList();

            var availableListenerLists = allListenerLists.Where(ll => !existingListenerLists.Contains(ll.Id)).ToList();

            AddListenerListViewModel viewModel = new AddListenerListViewModel
            {
                PodcastId = podcastId,
                Podcasts = new List<Podcast> { podcast },
                ListenerLists = availableListenerLists
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToListenerList(AddListenerListViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Podcasts = _context.Podcast.ToList();
                viewModel.ListenerLists = _context.ListenerList.ToList();
                return View(viewModel);
            }

            PodcastListenerList podcastListenerList = new PodcastListenerList
            {
                PodcastId = viewModel.PodcastId,
                ListenerListId = viewModel.ListenerListId,
            };

            _context.PodcastListenerLists.Add(podcastListenerList);
            _context.SaveChanges();

            return RedirectToAction("Details", "Podcasts", new { id = viewModel.PodcastId });
        }



        // GET: Podcasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Podcasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podcast);
        }

        // GET: Podcasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast.FindAsync(id);
            if (podcast == null)
            {
                return NotFound();
            }
            return View(podcast);
        }

        // POST: Podcasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate")] Podcast podcast)
        {
            if (id != podcast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastExists(podcast.Id))
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
            return View(podcast);
        }

        // GET: Podcasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcast == null)
            {
                return NotFound();
            }

            return View(podcast);
        }

        // POST: Podcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Podcast == null)
            {
                return Problem("Entity set 'MusicSystemContext.Podcast'  is null.");
            }
            var podcast = await _context.Podcast.FindAsync(id);
            if (podcast != null)
            {
                _context.Podcast.Remove(podcast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastExists(int id)
        {
          return (_context.Podcast?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
