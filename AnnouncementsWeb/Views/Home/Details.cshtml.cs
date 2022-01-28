using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AnnouncementsWeb.Model;

namespace AnnouncementsWeb.Views
{
    public class DetailsModel : PageModel
    {
        private readonly AnnouncementsWeb.Model.CAnnContext _context;

        public DetailsModel(AnnouncementsWeb.Model.CAnnContext context)
        {
            _context = context;
        }

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
    }
}
