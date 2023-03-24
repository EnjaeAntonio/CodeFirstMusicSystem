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
    public class SongsController : Controller
    {
        private readonly MusicSystemContext _context;

        public SongsController(MusicSystemContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var musicSystemContext = _context.Song
                .Include(s => s.Album)
                .Include(s => s.SongContributors)
                .ThenInclude(sc => sc.Artist);
            return View(await musicSystemContext.ToListAsync());
        }


        public ActionResult AddSongToPlaylist()
        {
            AddSongViewModel viewModel = new AddSongViewModel
            {
                Playlists = _context.Playlist.ToList(),
                Songs = _context.Song.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddSongToPlaylist(AddSongViewModel viewModel)
        {
            PlaylistSong playlistSong = new PlaylistSong
            {
                SongId = viewModel.SongId,
                PlaylistId = viewModel.PlaylistId
            };
            _context.PlaylistSong.Add(playlistSong);
            _context.SaveChanges();

            return RedirectToAction("Index", "Songs");
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }
        // GET: Songs/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Album, "Id", "Id");
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Name");
            return View(new CreateSongViewModel());
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DurationSeconds,AlbumId,ArtistId")] CreateSongViewModel createSongViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(createSongViewModel.Song);
                await _context.SaveChangesAsync();
                SongContributor songContributor = new SongContributor(createSongViewModel.ArtistId, createSongViewModel.Song.Id);
                _context.SongContributor.Add(songContributor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Album, "Id", "Id", createSongViewModel.Song.AlbumId);
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Name", createSongViewModel.ArtistId);
            return View(createSongViewModel);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Album, "Id", "Id", song.AlbumId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DurationSeconds,AlbumId")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
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
            ViewData["AlbumId"] = new SelectList(_context.Album, "Id", "Id", song.AlbumId);
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Song == null)
            {
                return Problem("Entity set 'MusicSystemContext.Song'  is null.");
            }
            var song = await _context.Song.FindAsync(id);
            if (song != null)
            {
                _context.Song.Remove(song);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
          return _context.Song.Any(e => e.Id == id);
        }
    }
}
