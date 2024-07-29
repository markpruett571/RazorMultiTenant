using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Data;
using MultiTenant.Models;

namespace MultiTenant.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly MultiTenant.Data.ApplicationDbContext _context;

        public DetailsModel(MultiTenant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TaskItem TaskItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.TaskItems.FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                TaskItem = task;
            }
            return Page();
        }
    }
}
