using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiTenant.Data;
using MultiTenant.Models;

namespace MultiTenant.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly MultiTenant.Data.ApplicationDbContext _context;

        public CreateModel(MultiTenant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TaskItemStatuses"] = Enum.GetValues(typeof(TaskItem.TaskItemStatus))
                                       .Cast<TaskItem.TaskItemStatus>()
                                       .Select(v => new SelectListItem
                                       {
                                           Text = v.ToString(),
                                           Value = ((int)v).ToString()
                                       })
                                       .ToList();

            return Page();
        }

        [BindProperty]
        public TaskItem TaskItem { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is not valid");
        // Log each model state error
        foreach (var modelState in ModelState)
        {
            foreach (var error in modelState.Value.Errors)
            {
                Console.WriteLine($"Error in {modelState.Key}: {error.ErrorMessage}");
            }
        }
                return Page();
            }

            try
            {
                var tenantId = User.FindFirstValue("TenantId");
                TaskItem.TenantId = Guid.Parse(tenantId);

                _context.TaskItems.Add(TaskItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 

            return RedirectToPage("./Index");
        }
    }
}
