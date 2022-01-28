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
    public class IndexModel : PageModel
    {
        private readonly AnnouncementsWeb.Model.CAnnContext _context;

        public IndexModel(AnnouncementsWeb.Model.CAnnContext context)
        {
            _context = context;
        }

        public IList<CAnnouncement> CAnnouncement { get;set; }

        public async Task OnGetAsync()
        {
            CAnnouncement = await _context.CAnnouncements.ToListAsync();
        }
    }
}
