#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AdminPanel.Models;

namespace AdminPanel.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly AdminPanel.Models.AssessmentDBContext _context;

        public CreateModel(AdminPanel.Models.AssessmentDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AssessmentResultGroup AssessmentResultGroup { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AssessmentResultGroups.Add(AssessmentResultGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
