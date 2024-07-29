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
    public class IndexModel : PageModel
    {
        private readonly MultiTenant.Data.ApplicationDbContext _context;

        public IndexModel(MultiTenant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskItem> TaskItems { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TaskItems = await _context.TaskItems
                .Include(t => t.Tenant).ToListAsync();
        }
    }
}
