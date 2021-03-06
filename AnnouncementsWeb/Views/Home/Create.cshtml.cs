using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AnnouncementsWeb.Model;

namespace AnnouncementsWeb.Views
{
    public class CreateModel : PageModel
    {
        private readonly AnnouncementsWeb.Model.CAnnContext _context;

        public CreateModel(AnnouncementsWeb.Model.CAnnContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CAnnouncement CAnnouncement { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CAnnouncements.Add(CAnnouncement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
