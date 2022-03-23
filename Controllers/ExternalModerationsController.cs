using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseDataManagement.Models;

namespace CourseDataManagement.Controllers
{
    public class ExternalModerationsController : Controller
    {
        private readonly ApplicationContext _context;

        public ExternalModerationsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ExternalModerations
        public async Task<IActionResult> Index()
        {
            return View(await _context.externalModeration.ToListAsync());
        }

        // GET: ExternalModerations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var externalModeration = await _context.externalModeration
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (externalModeration == null)
            {
                return NotFound();
            }

            return View(externalModeration);
        }

        // GET: ExternalModerations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExternalModerations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,CourseName,NameOfExternalModerator,DatePassedToExternalModerator,DateOfExternalmoderatorReport,DateOfResponseToReport,NextDueDateForExternalModeration,SendEmailNotificationTo")] ExternalModeration externalModeration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(externalModeration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(externalModeration);
        }

        // GET: ExternalModerations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var externalModeration = await _context.externalModeration.FindAsync(id);
            if (externalModeration == null)
            {
                return NotFound();
            }
            return View(externalModeration);
        }

        // POST: ExternalModerations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CourseID,CourseName,NameOfExternalModerator,DatePassedToExternalModerator,DateOfExternalmoderatorReport,DateOfResponseToReport,NextDueDateForExternalModeration,SendEmailNotificationTo")] ExternalModeration externalModeration)
        {
            if (id != externalModeration.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(externalModeration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExternalModerationExists(externalModeration.CourseID))
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
            return View(externalModeration);
        }

        // GET: ExternalModerations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var externalModeration = await _context.externalModeration
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (externalModeration == null)
            {
                return NotFound();
            }

            return View(externalModeration);
        }

        // POST: ExternalModerations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var externalModeration = await _context.externalModeration.FindAsync(id);
            _context.externalModeration.Remove(externalModeration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExternalModerationExists(string id)
        {
            return _context.externalModeration.Any(e => e.CourseID == id);
        }
    }
}
