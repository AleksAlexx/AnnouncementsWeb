using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnnouncementsWeb.Model;

namespace AnnouncementsWeb.Views
{
    public class EditModel : PageModel
    {
        private readonly AnnouncementsWeb.Model.CAnnContext _context;

        public EditModel(AnnouncementsWeb.Model.CAnnContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CAnnouncement CAnnouncement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CAnnouncement = await _context.CAnnouncements.FirstOrDefaultAsync(m => m.AnnId == id);

            if (CAnnouncement == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CAnnouncement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAnnouncementExists(CAnnouncement.AnnId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CAnnouncementExists(int id)
        {
            return _context.CAnnouncements.Any(e => e.AnnId == id);
        }
    }
}
